using System.Collections.Generic;

namespace Senserv.Model
{
    public class Batches
    {
        public List<Batch> BatchList { get; set; }
    }
}



public class Batch
{
    public string id { get; set; }
    public string analystId { get; set; }
    public object captureTime { get; set; }
    public string comments { get; set; }
    public string objective { get; set; }
    public string priority { get; set; }
    public string mgrs { get; set; }
    public int filesRemaining { get; set; }
    public string sourceDb { get; set; }
    public string[] languages { get; set; }
    public string step { get; set; }
    public string[] groups { get; set; }
    public Classification classification { get; set; }
}

public class Classification
{
    public string level { get; set; }
    public object scis { get; set; }
    public object saps { get; set; }
    public Aea aea { get; set; }
    public object owners { get; set; }
    public object disseminations { get; set; }
    public object otherDisseminations { get; set; }
    public string classificationString { get; set; }
    public string portionString { get; set; }
}

public class Aea
{
    public string value { get; set; }
}
