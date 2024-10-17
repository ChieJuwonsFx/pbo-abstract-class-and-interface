namespace SabungRobot;

interface IKemampuan{
    int perbaikan(Heal heal);
    double S_Listrik(Electric electric);
    double S_Plasma (Plasma plasma);
    int Pertahanan_Shield(Shield shield);
}

public class Kemampuan:IKemampuan{
    public Electric electric;
    public Plasma plasma;
    public Shield shield;
    public Heal heal;

    public Kemampuan(){
        this.plasma = new Plasma();
        this.shield = new Shield();
        this.heal = new Heal();
        this.electric = new Electric();

    }
    public int perbaikan(Heal heal) {
        return heal.energy;
    }

    public double S_Listrik(Electric electric){
        Console.WriteLine($"\n============================");
        Console.WriteLine("Menyerang dengan Electric Shock");
        Console.WriteLine($"============================");
        electric.now_cd = electric.cd + 1;
        return electric.kerusakan;
    }

    public double S_Plasma(Plasma plasma){
        Console.WriteLine($"\n============================");
        Console.WriteLine("Menyerang dengan Plasma Canon !");
        Console.WriteLine($"============================");
        plasma.now_cd = plasma.cd + 1;
        return plasma.kerusakan;
    }
    
    public int Pertahanan_Shield(Shield Shield){
        Console.WriteLine($"\n============================");
        Console.WriteLine("Melakukan Pelindung Tambahan !");
        Console.WriteLine($"============================");
        shield.now_cd = shield.cd + 1;
        shield.sisa_waktu = shield.waktu;
        return shield.jumlah;
    }
}

public class Electric : Skill{

    public Electric(){
        this.name = "Electric";
        this.cd = 1;
        this.kerusakan = 1.5;
    }
}

public class Plasma : Skill{
    public Plasma(){
        this.name = "Plasma";
        this.cd = 2;
        this.kerusakan = 2;
    }
}

public class Tank : Skill{
    public Tank(){
        this.name = "Tank";
        this.cd = 2;
        this.kerusakan = 2;
    }
}

public class Shield{
    public int waktu, jumlah,now_cd, sisa_waktu;
    public int cd = 4;
    public Shield(){
        this.waktu = 2;
        this.jumlah = 20;
    }
}

public class Heal{
    public int energy = 40;
}


public abstract class Skill{
    public string name;
    public double kerusakan;
    public int cd;
    public int now_cd;

}