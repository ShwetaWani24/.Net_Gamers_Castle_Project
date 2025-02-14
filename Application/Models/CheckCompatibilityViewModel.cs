using Entities;

public class CheckCompatibilityViewModel
{
    public Game Game { get; set; }
    public PcSpecifications UserPcSpecs { get; set; }
    public int EstimatedFps { get; set; }
}

public class PcSpecifications
{
    public string GPU { get; set; }
    public string CPU { get; set; }
    public int RAM { get; set; } // in GB
}
