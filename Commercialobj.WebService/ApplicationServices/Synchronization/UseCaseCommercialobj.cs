using System;
using System.Collections.Generic;
using System.Net;
using Commercialobj.DomainObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Commercialobj.InfrastructureServices.Gateways.Database;

namespace Commercialobj.ApplicationServices.Synchronization
{
    public class Commercialobj_Cell
    {
        public int global_id { get; set; }
        public int Number { get; set; }
        public Commercialobj_inf Cells { get; set; }   
    }

    public class Commercialobj_inf
    {
        public string Name { get; set; }
        public string AdmArea { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string FacilityArea { get; set; }
        public string ObjectType { get; set; }
        //public string Specialization { get; set; }
        public string PeriodOfPlacement { get; set; }
        public string NameOfBusinessEntity { get; set; }
    }

    public class UseCaseCommercialobj
    {
        static string remoteUri = "https://apidata.mos.ru/v1/datasets/619/rows?api_key=8165ee9d08a3442652f9b5d3b9d20fa7";

        string path = @".\update_database\commercialobj-";
        
        List<Commercialobj_Cell> commercialobj_cells;

        public List<commercialobj> commercialobjs = new List<commercialobj>();

        public UseCaseCommercialobj()
        {
            
            WebRequest request = WebRequest.Create(remoteUri);
            WebResponse response = request.GetResponse();
           
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string line = stream.ReadToEnd();
            
            JArray jsonArray = JArray.Parse(line);
            
            commercialobj_cells = JsonConvert.DeserializeObject<List<Commercialobj_Cell>>(jsonArray.ToString());
         
            DateTime Date_update = DateTime.Now;
            string date_update = Date_update.ToShortDateString();

            path = path + date_update + @".json";
            
            using (FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate))
            {
                
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                
                string text = "[";
                byte[] input = Encoding.Default.GetBytes(text);
               
                fs2.Write(input, 0, input.Length);
                text = ",";

                for (int i = 0; i < commercialobj_cells.Count; i++)
                {
                    commercialobjs.Add(new commercialobj()
                    {
                        Name = commercialobj_cells[i].Cells.Name,
                        Id = commercialobj_cells[i].Number,
                        Address = commercialobj_cells[i].Cells.Address,
                        District = commercialobj_cells[i].Cells.District,
                        AdmArea = commercialobj_cells[i].Cells.AdmArea,
                        FacilityArea = commercialobj_cells[i].Cells.FacilityArea,
                        ObjectType = commercialobj_cells[i].Cells.ObjectType,
                        //Specialization = commercialobj_cells[i].Cells.Specialization,
                        PeriodOfPlacement = commercialobj_cells[i].Cells.PeriodOfPlacement,
                        NameOfBusinessEntity = commercialobj_cells[i].Cells.NameOfBusinessEntity
                    });

                    System.Text.Json.JsonSerializer.SerializeAsync<commercialobj>(fs2, commercialobjs[i], options).GetAwaiter().GetResult();

                    if (i != commercialobj_cells.Count - 1)
                    {
                        input = Encoding.Default.GetBytes(text);
                        fs2.Write(input, 0, input.Length);
                    }
                }

                text = "]";
                input = Encoding.Default.GetBytes(text);
                fs2.Write(input, 0, input.Length);
            }   
        }
    }
}

