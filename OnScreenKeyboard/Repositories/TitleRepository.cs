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



            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
