using Microsoft.CodeAnalysis.Editing;
using SportsPro.Models;
using System.Collections.Generic;
namespace SportsPro2_5.ViewModels;

public class IncidentViewModel {

    public List<Incident> Incidents { get; set; }
    public string IncidentState { get; set; } = "all";
}
