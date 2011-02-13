﻿using System;
using System.IO;
using System.Xml;
using NTextSearch;

namespace NTextSearchXmlPlugin {
    [TextSearchEngine]
    public class TextSearchXmlEngine : AbstractTextSearchPlugin {

        public TextSearchXmlEngine(){
            SearchInValues = true;
            SearchInElements = false;
        }

        public override string FileExtention {
            get { return FileExtentions.XML; }
        }

        protected override string InnerTitle {
            get { return "XML files"; }
        }

        protected override void PerformSearchIn(FileInfo fileInfo){
            try{
                var document = new XmlDocument();
                using (FileStream stream = fileInfo.OpenRead()){
                    document.Load(stream);
                    if (ValidateTextExistIn(document.ChildNodes)){
                        Notify(fileInfo, TextSearchStatus.TextFoundInFile);
                        return;
                    }
                }
            }
            catch(Exception ex){
                Notify(fileInfo, TextSearchStatus.Error, ex.Message);
                return;
            }
            Notify(fileInfo, TextSearchStatus.TextNotFoundInFile);
        }

        private bool SearchInValues { get; set; }
        private bool SearchInElements { get; set; }

        private bool ValidateTextExistIn(XmlNodeList nodes){
            if (nodes == null)
                return false;
            foreach (XmlNode node in nodes){
                //TODO - check for requested break (or reset)
                if (ValidateTextExistsIn(node)) 
                    return true;
                if (node.Attributes != null){
                    foreach (XmlAttribute attribute in node.Attributes){
                        if (ValidateTextExistsIn(attribute))
                            return true;
                    }
                }
                if (ValidateTextExistIn(node.ChildNodes))
                    return true;
            }
            return false;
        }

        private bool ValidateTextExistsIn(XmlNode element){
            if ((SearchInValues && ValidateTextExistsIn(element.Value))
                || (SearchInElements && ValidateTextExistsIn(element.Name)))
                return true;
            return false;
        }
    }
}