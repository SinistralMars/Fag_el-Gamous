using Microsoft.ML.OnnxRuntime.Tensors;
using System.Text.Json.Serialization;

namespace Fag_el_Gamous.Models
{
public class BurialDataModel
{
    [JsonPropertyName("squarenorthsouth")]
    public float SquareNorthSouth { get; set; }

    [JsonPropertyName("depth")]
    public float Depth { get; set; }

    [JsonPropertyName("southtohead")]
    public float SouthToHead { get; set; }

    [JsonPropertyName("squareeastwest")]
    public float SquareEastWest { get; set; }

    [JsonPropertyName("westtohead")]
    public float WestToHead { get; set; }

    [JsonPropertyName("length")]
    public float Length { get; set; }

    [JsonPropertyName("westtofeet")]
    public float WestToFeet { get; set; }

    [JsonPropertyName("southtofeet")]
    public float SouthToFeet { get; set; }

    [JsonPropertyName("sex_F")]
    public float Sex_F { get; set; }

    [JsonPropertyName("sex_M")]
    public float Sex_M { get; set; }

    [JsonPropertyName("eastwest_W")]
    public float EastWest_W { get; set; }

    [JsonPropertyName("adultsubadult_A")]
    public float AdultSubAdult_A { get; set; }

    [JsonPropertyName("adultsubadult_C")]
    public float AdultSubAdult_C { get; set; }

    [JsonPropertyName("adultsubadult_N")]
    public float AdultSubAdult_N { get; set; }

    [JsonPropertyName("wrapping_B")]
    public float Wrapping_B { get; set; }

    [JsonPropertyName("wrapping_H")]
    public float Wrapping_H { get; set; }

    [JsonPropertyName("wrapping_S")]
    public float Wrapping_S { get; set; }

    [JsonPropertyName("wrapping_W")]
    public float Wrapping_W { get; set; }

    [JsonPropertyName("haircolor_A")]
    public float HairColor_A { get; set; }

    [JsonPropertyName("haircolor_B")]
    public float HairColor_B { get; set; }

    [JsonPropertyName("haircolor_D")]
    public float HairColor_D { get; set; }

    [JsonPropertyName("haircolor_K")]
    public float HairColor_K { get; set; }

    [JsonPropertyName("haircolor_R")]
    public float HairColor_R { get; set; }

    [JsonPropertyName("samplescollected_false")]
    public float SamplesCollected_False { get; set; }

    [JsonPropertyName("samplescollected_true")]
    public float SamplesCollected_True { get; set; }

    [JsonPropertyName("samplescollected_unknown")]
    public float SamplesCollected_Unknown { get; set; }

    [JsonPropertyName("area_NNW")]
    public float Area_NNW { get; set; }

    [JsonPropertyName("area_NW")]
    public float Area_NW { get; set; }

    [JsonPropertyName("area_SE")]
    public float Area_SE { get; set; }

    [JsonPropertyName("area_SW")]
    public float Area_SW { get; set; }

    [JsonPropertyName("ageatdeath_A")]
    public float AgeAtDeath_A { get; set; }

    [JsonPropertyName("ageatdeath_C")]
    public float AgeAtDeath_C { get; set; }

    [JsonPropertyName("ageatdeath_I")]
    public float AgeAtDeath_I { get; set; }
    [JsonPropertyName("ageatdeath_IN")]
    public float AgeAtDeath_IN { get; set; }
    [JsonPropertyName("ageatdeath_N")]
    public float AgeAtDeath_N { get; set; }
}
}