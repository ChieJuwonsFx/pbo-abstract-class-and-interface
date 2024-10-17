// using Robofight;

// namespace PerangAtlantis;

// class Program{
//     static void Main(string[] args)
//     {
//         Main main = new Main();

//     }
// }

// public class Main{
    
// }

// public abstract class Robot{
//     public string nama;
//     public int energi, armor, serangan;
//     public bool gunakanKemampuan(Kemampuan kemampuan, Robot target, string Skill){
//         if (Skill == "Regen"){

//         }
//         else if (Skill == "Electric"){
            
//         }
//         else if (Skill == "Plasma"){
            
//         }
//         else if (Skill == "Shield"){
            
//         }
//         else{
//             return false;
//         }
//         return true
//     }
    
//     public void CekSikon(){
//         Console.WriteLine($"Nama : {nama}\nEnergi : {energi}\nArmor : {armor}");
//     }
//     public void Serang(Robot target){
//         Console.WriteLine($"Menyerang Robot {target.nama} !!");
//         if(target.armor > this.serangan)
//         {
//             target.armor -= this.serangan;          
//         }
//         else if (target.armor == 0)
//         {
//             target.energi -= this.serangan;
//         }
//         else
//         {
//             target.energi -= this.serangan - target.armor;
//             target.armor = 0;
//         }
//     }
// }

// public class Boss : Robot{
//     public Boss (){
//         this.nama = "Boss";
//         this.energi = 300;
//         this.armor = 100;
//         this.serangan = 20;
//     }
// }

// public class Elektrik : Robot{
//     public Elektrik(){
//         this.nama = "Elektrik";
//         this.energi = 100;
//         this.armor = 50;
//         this.serangan = 30;
//     }
// }

// public class Plasma : Robot{
//     public Plasma(){
//         this.nama = "Elektrik";
//         this.energi = 100;
//         this.armor = 50;
//         this.serangan = 30;
//     }
// }

// public abstract class Skill{
//     public string name;
//     public int kerusakan, cd, now_cd;
// }

// interface ISkill{
//     int recover(Healing heal);
//     int S_Listrik(Listrik listrik);
//     int S_Plasma(Plasm plasma);
//     int S_Shield(Shields shield);
// }



// public class Heal{
//     public int energy = 50;
// }

// public class Shield{
//     public int durasi, jumlah, now_cd, waktu;
//     public int cd = 3;
//     public Shield (){
//         this.waktu = 2;
//         this.jumlah = 25;
//     }
// }













namespace SabungRobot;

class Program{
    static void Main(string[] args)
    {
        Console.WriteLine($"\n==============================================");
        Console.WriteLine($"============ Bakar Robot Musuhmu =============");
        Console.WriteLine($"==============================================");
        Permainan game = new Permainan();
        game.Pilih_Robot();
        game.Mulai_Permainan();
    }
}



