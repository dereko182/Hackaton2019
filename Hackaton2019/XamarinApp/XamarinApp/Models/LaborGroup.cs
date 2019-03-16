using SharedModels;
using System.Collections.Generic;

namespace XamarinApp.Models
{
    public class LaborGroup : List<LaborModel>
    {
            public string Heading { get; set; }
            public List<LaborModel> Labores => this;
        
    }
}