namespace SabungRobot;
public abstract class Robot{
    public string nama;
    public int energi ,armor ,serangan;
    public bool Gunakan_kemampuan(Kemampuan kemampuan,Robot target,string Skill){
        if (Skill == "Plasma"){
                if(kemampuan.plasma.now_cd > 0)
                {
                    return false;
                }
                if(target.armor > kemampuan.plasma.kerusakan * this.serangan)
                {
                    target.armor -= Convert.ToInt32(kemampuan.S_Plasma(kemampuan.plasma) * this.serangan);
                }
                else if (target.armor == 0)
                {
                    target.energi -= Convert.ToInt32(kemampuan.S_Plasma(kemampuan.plasma) * this.serangan);
                }
                else
                {
                    kemampuan.S_Plasma(kemampuan.plasma);
                    target.energi -= Convert.ToInt32(kemampuan.plasma.kerusakan * this.serangan) - target.armor;
                    target.armor = 0;
                }
                return true;
                }
        else if (Skill == "Electric"){            
                if(kemampuan.electric.now_cd > 0)
                {
                    return false;
                }
                if(target.armor > kemampuan.electric.kerusakan * this.serangan)
                {
                    target.armor -= Convert.ToInt32(kemampuan.S_Listrik(kemampuan.electric) * this.serangan);
                    
                }
                else if (target.armor == 0)
                {
                    target.energi -= Convert.ToInt32(kemampuan.S_Listrik(kemampuan.electric) * this.serangan);
                }
                else{
                    kemampuan.S_Listrik(kemampuan.electric);
                    target.energi -= Convert.ToInt32(kemampuan.electric.kerusakan * this.serangan) - target.armor;
                    target.armor = 0;
                }
                return true;
                }
        else if (Skill ==  "Shield"){
                if(kemampuan.shield.sisa_waktu > 0 || kemampuan.shield.now_cd > 0)
                {
                    return false;
                }
                target.armor += kemampuan.Pertahanan_Shield(kemampuan.shield);
                return true;}
        else if (Skill ==  "Heal"){
                target.energi += kemampuan.perbaikan(kemampuan.heal);
                if (target.energi > 100)
                {
                    target.energi = 100;
                }
                return true;}
        else{
            return true;
        }
    }
    
    public void CekSikon()
    {
        Console.WriteLine($"========== Kondisi Robot =========");
        Console.WriteLine($"Nama : {nama}\nEnergi : {energi}\nArmor : {armor}");
        Console.WriteLine($"==================================");
    }
    public void Serang(Robot targeting)
    {
        Console.WriteLine($"Menyerang Robot {targeting.nama} !!");
        if(targeting.armor > this.serangan)
        {
            targeting.armor -= this.serangan;          
        }
        else if (targeting.armor == 0)
        {
            targeting.energi -= this.serangan;
        }
        else
        {
            targeting.energi -= this.serangan - targeting.armor;
            targeting.armor = 0;
        }
    }
}


public class Boss : Robot
{
    public Boss()
    {
        this.nama = "Boss";
        this.energi = 250;
        this.armor = 80 ;
        this.serangan = 30;
    }
}

public class R_Electric : Robot{
    public R_Electric()
    {
        this.nama = "Electro";
        this.energi = 120;
        this.armor = 60;
        this.serangan = 90;
    }
}

public class R_Plasma : Robot
{
    public R_Plasma()
    {
        this.nama = "Plasma";
        this.energi = 120;
        this.armor = 60;
        this.serangan = 90;
    }
}