using System;
using System.Collections.Generic;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;

namespace Tranzact.Wikimedia.Core
{
    public class ProcessConversionData : IProcessConversionData
    {
        public IEnumerable<FileContentEntity> ConvertDataToProcess(IList<FileContentEntity> filesContent, IList<Codedentity> codes)
        {
            var listCodes = new List<Codedentity>(codes);
            var listFiles = new List<FileContentEntity>(filesContent);

    
            listFiles.ForEach(item =>
            {
               
                item.domain = GetDomain(item, listCodes);
                item.language = GetLanguage(item, listCodes);
            });

            return listFiles;

        }

        public string GetDomain(FileContentEntity filesContent, List<Codedentity> codes)
        {
            if (filesContent.domainCode!=null)
            {
                string[] words = filesContent.domainCode.Split('.');

                if (words.Length >1)
                {
                    string code = words[words.Length - 1];
                    if (code == "")
                    {
                        return codes[0].description;
                    }
                    else
                    {

                        var result = codes.Find(x => x.code== code); 


                        return result.description; 


                    }
                }   
                else
                {
                    return codes[0].description;
                }
            }

            return "";

            }
        public string GetLanguage(FileContentEntity filesContent, List<Codedentity> codes)
        {
            if (filesContent.domainCode != null)
            {
                string[] words = filesContent.domainCode.Split('.');

                if (words.Length > 1)
                {
                    string code = words[words.Length - 1];
                    if (code == "")
                    {
                        return words[0];
                    }
                    else
                    {

                        var result = codes.Find(x => x.code == code);

                        if (result.listSubdomains != null && result.listSubdomains.Count > 0)
                        {
                            var subDomain = result.listSubdomains.Find(x => x == words[0]);

                            if (subDomain != null)
                            {
                                return "en";
                            }
                            else
                            {
                                return words[0];
                            }

                        }
                        else
                        {
                            return result.code;
                        }


                    }
                }
                else
                {
                    return words[0];
                }
            }
            else
            {
                return "";
            }


        }
    }

    }

 
 