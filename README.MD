#Test LPS
Ini adalah Repository untuk Tes Nomor 1 sampai 7
Jawaban dapat dilihat langsung pada code yang sudah saya beri region untuk setiap nomornya
berikut penjelasan dari setiap nomor

-- Nomor 1

dalam ASP.NET Core penggunaan kondisi null dapat diganti dengan simbol "?" sehingga tidak diperlukan if-else operator untuk penulisannya, berikut code pengganti-nya

"return application?.protected?.shieldLastRun;"

di dalam code yang saya buat jawabannya agak berbeda yaitu
"Console.WriteLine("Nomor 1 = " + application?.@protected?.shieldLastRun.ToString());"
saya juga menyertakan beberapa modifikasi untuk tujuan presentasi code yang dapat berjalan, untuk nomor 1 saya menambahkan 2 class untuk memberikan return saat dipanggil oleh main function

== Nomor 2

disini saya menggunakan custom class untuk me-return value tersebut. Method yang diberikan soal saya modifikasi menjadi static method, dan membuat class baru untuk bernama applicationinfo sebagai setter dan getter bagi variabel Path dan Name, lalu pada Main function saya menambahkan kode berikut
"
 //no2
 var info = GetInfo();
 var path = info.Path;
 var name = info.Name;
 Console.WriteLine("Nomor 2 = " + $"{path} {name}");
 "

 -- nomor 3
 
class yang diberikan saya ubah menjadi sebagai berikut
{
class Laptop
{
    private string _os;
    public Laptop(string os) { _os = os; }

    public string os { get { return _os; } private set { _os = value; } }

    public void ModifyOS(string newOs) { _os = newOs; }
}
}
saat saya akan membuat value baru pada variable os yang masih kosong saya akan memanggil method laptop
"var laptop = new Laptop("macOs");"
saat variable os dipanggil "Console.WriteLine(laptop.os)" maka yang akan ter-print adalah "macOs", berikutnya saya membuat modifikasi sebagai berikut
 Console.WriteLine("type to modify the os:");
 string a = Console.ReadLine();
 laptop.ModifyOS(a);
 Console.WriteLine("After modifying the value : " + laptop.os);
dengan code diatas akan muncul prompt untuk input os yang diinginkan pada terminal dan akan menampilkan serta mengubah value dari variable os

--nomor 4

nomor 4 adalah contoh dari memory leak, dari code yang diberikan ini membuat terjadinya memeroy leak karena data tidak dimanage pada saat infinite loop. solusinya adalah menambahkan satu baris code yaitu "myList.Clear()" ini bertujuan untuk menghapus data yang sebelumya telah di-generate untuk dihapuskan karena tidak lagi dibutuhkan sehingga dapat mencegah terjadinya memory leak.

--nomor 5

nomor 5 hampir sama seperti nomor 4, solusinya adalah mengimplementasi IDisposable interface dan membuat method baru yang dinamakan Dispose yang bertugas untuk unsubscribe saat subscriber tidak lagi dibutuhkan.

--nomor 6

dalam code yang diberikan pada nomor 6, grafik yang berpotensi berukuran besar dibuat melalui infinite loop, setiap TreeNode memiliki list dari child node dan setiap child node bisa memiliki turunannya masing2 hal ini nantinya akan menghasilkan grafik yang kompleks dan berukuran besar. Untuk mencegah masalah pada memory saat men-generate hal yang harus dipastikan adalah membuang object yang tidak lagi dibutuhkan.

dalam code yang saya modifikasi, saya membuat method "CreateSubtree" method ini bertujuan untuk membuat subtree dengan jumlah node yang spesifik, pada Main Function menambahkan subtree pada rootNode dengan tujuan membuat kedalaman yang spesifik bagi object graph tersebut. dengan ini kedalaman dan jumlah node yang dibuat dapat disesuaikan dengan jumlah yang diiginkan atau ketersediaan memori

--nomor 7

