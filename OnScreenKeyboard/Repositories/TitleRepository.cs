using OnScreenKeyboard.Interfaces;
using OnScreenKeyboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;


namespace OnScreenKeyboard.Repositories
{

    public class Title : ITitle
    {
        private string _filename = ConfigurationManager.AppSettings["DataFile"];

        public List<TitleModel> GetTitles()
        {


            var returnTitles = new List<TitleModel>();
            try
            {
                var titles = File.ReadAllLines(_filename);


                foreach (var t in titles)
                {
                    var tempModel = new TitleModel();
                    tempModel.DvrTitle = t.ToString();
                    returnTitles.Add(tempModel);


                }

            }
            catch (Exception)
            {

                throw;
            }
            return returnTitles;

        }
    }


}
