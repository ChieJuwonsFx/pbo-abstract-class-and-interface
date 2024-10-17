namespace SabungRobot;
public class Permainan{
    Robot Player;
    string Jenis_Robot;
    Robot Musuh;
    Kemampuan a_pemain;
    Kemampuan a_musuh;
    public Kemampuan SkillList;

    int turn = 1; 
    public Permainan(){
        this.Musuh = new Boss();
        this.a_musuh = new Kemampuan();
        this.a_pemain = new Kemampuan();
    }

    public void Pilih_Robot(){
        string opsi;
        do{
            Console.WriteLine($"\n============ Pilih Robotmu =============");
            Console.WriteLine("Silahkan Memilih Robot \n1. Robot Electro\n2. Robot Plasma");
            Console.Write("Pilihan Robot : ");
            opsi = Console.ReadLine();
            Console.Clear();
        }
        while(opsi != "1" && opsi != "2");
        if (opsi == "1"){
                this.Player = new R_Electric();
                this.Jenis_Robot = "Robot Electric";
            }
        else if (opsi == "2"){
                this.Player = new R_Plasma();
                this.Jenis_Robot = "Robot Plasma";
            }
    }

    public void Mulai_Permainan(){
        while(true){
            this.Min_cd();
            this.Sesi_Pemain();
            if (Player.energi < 0 || Musuh.energi < 0 || turn == 10)
            {
                Console.WriteLine($"\n===================================");
                Console.WriteLine("Game Telah Berakhir");
                Console.WriteLine($"Game Berhasil Dimenangkan Oleh {this.Pemenang()}");
                Console.WriteLine($"==================================");
                break;
            }
            Console.Write("Tekan Enter Untuk Lanjut");
            Console.ReadLine(); 
            this.Musuh_session();

            if (Player.energi < 0 || Musuh.energi < 0 || turn == 10)
            {
                Console.WriteLine($"\n===================================");
                Console.WriteLine("Game Telah Berakhir");
                Console.WriteLine($"Game Berhasil Dimenangkan Oleh {this.Pemenang()}");
                Console.WriteLine($"===================================");
                break;
            } 
            this.Player.Gunakan_kemampuan(this.a_pemain,this.Player,"Regen");
            this.turn ++;
            Console.Write("Tekan Enter Untuk Lanjut");
            Console.ReadLine(); 
        }
    }
    public void Sesi_Pemain(){
        bool status_aksi = false;
        String ability;
        if(this.Jenis_Robot == "Robot Plasma"){
            ability = "Plasma";
        }else{
            ability = "Electric";
        }
        string opsi;
        do{
            Console.Clear();
            Console.WriteLine($"Turn : {this.turn}");
            Player.CekSikon();
            Console.WriteLine($"\n============ Pilih Skill =============");
            Console.WriteLine("1. Serang\n2. Gunakan Kemampuan Spesial\n3. Aktifkan Pertahanan Tambahan");
            Console.WriteLine($"======================================");
            Console.Write("Pilihan : ");
            opsi = Console.ReadLine();
        }while(opsi != "1" && opsi != "2" && opsi != "3");
        if (opsi == "1"){
                Player.Serang(this.Musuh);
                status_aksi = true;
            }
        else if (opsi == "2"){
                status_aksi = (Player.Gunakan_kemampuan(this.a_pemain,this.Musuh,ability));
            }
        else if (opsi == "3"){
                status_aksi = (Player.Gunakan_kemampuan(this.a_pemain,this.Player,"Shield"));
            } 
        if(!(status_aksi)){;
            this.Sesi_Pemain();}
        }
        
    public void Musuh_session(){
        Console.Clear();
        Musuh.CekSikon();
        Random random = new Random();
        bool status_aksi = false;
        string[] aksi = {"Electric","Plasma","Serang"};
        string opsi = aksi[random.Next(aksi.Length)];
        if (opsi == "Serang"){
                Player.Serang(this.Player);
                status_aksi = true;
        }
        else if (opsi == "Electric"){
                status_aksi = (Musuh.Gunakan_kemampuan(this.a_musuh,this.Player,"Plasma"));
        }
        else if (opsi == "Plasma"){
                status_aksi = (Musuh.Gunakan_kemampuan(this.a_musuh,this.Player,"Electric"));
        } 
        if(!(status_aksi)){this.Musuh_session();}
    }

    public string Pemenang(){
        if (Player.energi > Musuh.energi){
            return Player.nama;
        }else{
            return Musuh.nama;
        }
    }

    public void Min_cd(){
        if(a_musuh.electric.now_cd > 0){
            a_musuh.electric.now_cd --;
        }
        if(a_musuh.shield.now_cd > 0){
            a_musuh.shield.now_cd --;
        }
        if(a_musuh.plasma.now_cd > 0){
            a_musuh.plasma.now_cd --;
        } 
        if(a_pemain.electric.now_cd > 0){
            a_pemain.electric.now_cd --;
        }
        if(a_pemain.shield.now_cd > 0){
            a_pemain.shield.now_cd --;
        }
        if(a_pemain.plasma.now_cd > 0){
            a_pemain.plasma.now_cd --;
        }

        if(a_pemain.shield.sisa_waktu == 0){
            if(Player.armor < a_pemain.shield.jumlah)
            {
                Player.armor = 0;
            }
            else
            {
                Player.armor -= a_pemain.shield.jumlah;
            }
        }

        if(a_musuh.shield.sisa_waktu == 0){
            if(Musuh.armor < a_musuh.shield.jumlah)
            {
                Musuh.armor = 0;
            }
            else
            {
                Musuh.armor -= a_musuh.shield.jumlah;
            }
        }
    }
}