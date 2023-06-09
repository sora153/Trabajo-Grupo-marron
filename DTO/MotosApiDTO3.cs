using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo.DTO
{
    public class MotosApiDTO3
{
    public ArticleCompleteInfo ArticleCompleteInfo { get; set; }
    public EngineAndTransmission EngineAndTransmission { get; set; }
    public ChassisSuspensionBrakesAndWheels ChassisSuspensionBrakesAndWheels { get; set; }
    public PhysicalMeasuresAndCapacities PhysicalMeasuresAndCapacities { get; set; }
    public OtherSpecifications OtherSpecifications { get; set; }
}

public class ArticleCompleteInfo
{
    public int ArticleID { get; set; }
    public string MakeName { get; set; }
    public string ModelName { get; set; }
    public string CategoryName { get; set; }
    public int YearName { get; set; }
}

public class EngineAndTransmission
{
    public string DisplacementName { get; set; }
    public string EngineTypeName { get; set; }
    public string EngineDetailsName { get; set; }
    public string PowerName { get; set; }
    public string TorqueName { get; set; }
    public string CompressionName { get; set; }
    public string BoreXStrokeName { get; set; }
    public string ValvesPerCylinderName { get; set; }
    public string FuelSystemName { get; set; }
    public string LubricationSystemName { get; set; }
    public string CoolingSystemName { get; set; }
    public string GearboxName { get; set; }
    public string TransmissionTypeFinalDriveName { get; set; }
    public string ClutchName { get; set; }
    public string DrivelineName { get; set; }
    public string ExhaustSystemName { get; set; }
}

public class ChassisSuspensionBrakesAndWheels
{
    public string FrameTypeName { get; set; }
    public string FrontBrakesName { get; set; }
    public string FrontBrakesDiameterName { get; set; }
    public string FrontSuspensionName { get; set; }
    public string FrontTyreName { get; set; }
    public string FrontWheelTravelName { get; set; }
    public string RakeName { get; set; }
    public string RearBrakesName { get; set; }
    public string RearBrakesDiameterName { get; set; }
    public string RearSuspensionName { get; set; }
    public string RearTyreName { get; set; }
    public string RearWheelTravelName { get; set; }
    public string TrailName { get; set; }
    public string WheelsName { get; set; }
}

public class PhysicalMeasuresAndCapacities
{
    public string DryWeightName { get; set; }
    public string FuelCapacityName { get; set; }
    public string OverallHeightName { get; set; }
    public string OverallLengthName { get; set; }
    public string OverallWidthName { get; set; }
    public string PowerWeightRatioName { get; set; }
    public string ReserveFuelCapacityName { get; set; }
    public string SeatHeightName { get; set; }
}

public class OtherSpecifications
{
    public string ColorOptionsName { get; set; }
    public string CommentsName { get; set; }
    public string FactoryWarrantyName { get; set; }
	public string ImportCountryName { get; set; }
    public string IntroductionYearName { get; set; }
    public string MakeWarrantyName { get; set; }
    public string ModelWarrantyName { get; set; }
    public string MSRPName { get; set; }
    public string OtherFeaturesName { get; set; }
    public string YearWarrantyName { get; set; }
}
}