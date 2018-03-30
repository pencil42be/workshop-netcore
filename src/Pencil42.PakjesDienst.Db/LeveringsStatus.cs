namespace Pencil42.PakjesDienst.Db
{
    public enum LeveringsStatus
    {
        Aangekondigd = 0,
        Geregistreerd = 1,
        OnderwegNaarTussenStation = 2,
        OnderwegNaarBestemming = 3,
        Geleverd = 4,
        TerugNaarDepot = 5
    }
}