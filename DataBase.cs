﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Security.Permissions;
using Newtonsoft.Json.Linq;
using System.CodeDom;
using System.Windows;
using System.Security.RightsManagement;

namespace WebShop
{
    internal class DataBase 
    {
        public List<Book> Records {  get; set; }
        public Book CurrentlySelected {  get; set; }
        public string ExportPath 
        {
            get
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();
                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == false) return null;

                // Open document
                return dialog.FileName;
            }
        }
        public string ImportPath { get; set; }

        public DataBase() 
        {
            Records = new List<Book>();
        }
        public void Import()
        {
            try
            {
                string jsonContent = File.ReadAllText(ImportPath);

                Records = JsonConvert.DeserializeObject<List<Book>>(jsonContent);

                //MessageBox.Show("Successful import!");
            }
            catch(Exception ex) //TODO  
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void Export() 
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(this.Records, Formatting.Indented);

                File.WriteAllText(ExportPath, jsonContent);

                MessageBox.Show("Successful export!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void Insert(Book book)
        {
            this.Records.Add(book);
        }

        public void Delete(Predicate<Book> predicate)
        {
            Records.RemoveAll(predicate);
        }
        public void Delete()
        {
            this.Records.Remove(CurrentlySelected);
        }
    }
}
