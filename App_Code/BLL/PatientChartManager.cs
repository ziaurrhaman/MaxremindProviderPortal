using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientChartManager
/// </summary>
public class PatientChartManager
{
    long PracticeId;
    long UserId;
    
	public PatientChartManager()
	{
        PracticeId = long.Parse(HttpContext.Current.Profile.GetPropertyValue("PracticeId").ToString());
        UserId = long.Parse(HttpContext.Current.Profile.GetPropertyValue("UserId").ToString());
	}

    public long CreateChart(PatientCharts objPatientCharts)
    {
        objPatientCharts.PracticeId = PracticeId;
        objPatientCharts.CreatedById = UserId;
        objPatientCharts.CreatedDate = DateTime.Now;
        
        PatientChartsDB objPatientChartsDB = new PatientChartsDB();
        return objPatientChartsDB.Add(objPatientCharts);
    }
}