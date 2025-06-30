# game-urp-unity3d
Proyek Final Mata Kuliah Pemrograman Game (UAS) - Game Desktop Unity 3D "Petualangan Koin Ajaib"
![image](https://github.com/user-attachments/assets/0894ca41-16ba-474c-82cc-5981b8cd5d30)
![Demo Game](assets/main_Demo Proyek)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Ringkasan Proyek
Proyek ini adalah pengembangan sebuah aplikasi permainan (game) berbasis desktop menggunakan **Unity 3D** sebagai bagian dari Ujian Akhir Semester (UAS) mata kuliah Pemrograman Game. Game ini menampilkan elemen eksplorasi, pengumpulan item dalam lingkungan 3D yang imersif.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Video Demonstrasi Lengkap Proyek
Berikut adalah tautan ke video demonstrasi terperinci untuk setiap aspek proyek, sesuai dengan penilaian UAS:

1.  **[SubCPMK 1] Desain Level & Integrasi Aset:**
    * **Deskripsi Singkat:** Demonstrasi level design game yang bebas tema, mencakup implementasi terrain dengan penumbuhan (pohon, rumput), tekstur terrain, gunung, sungai, skybox, dan objek 3D di dalamnya.
2.  **[SubCPMK 2] Implementasi Karakter & Game Playable:**
    * **Deskripsi Singkat:** Video ini memperlihatkan implementasi karakter 3D dengan fitur pergerakan lengkap (maju, mundur, kiri, kanan), *view* kamera Third Person Shooter (TPS), atribut poin dan nyawa (nilai awal 100), sistem koin 3D dengan berbagai warna dan interaksi (poin/nyawa bertambah/berkurang, lampu menyala/mati), serta tampilan poin dan nyawa pada UI Text.
    * **Tonton Video:** [[LINK_VIDEO_YOUTUBE_SUB_CPMK_1_2](https://youtu.be/vmRV63Z-L6E)]

3.  **[SubCPMK 3] Konfigurasi Render Pipeline (URP/HDRP):**
    * **Deskripsi Singkat:** Demonstrasi langkah-langkah rinci konfigurasi Universal Render Pipeline (URP) pada terrain game, sesuai dengan tema visual game. (Video ini menjelaskan proses teknis konfigurasi).
    * **Tonton Video:** [[LINK_VIDEO_YOUTUBE_SUB_CPMK_3](https://youtu.be/yX0TUQmKgUc)]

4.  **[SubCPMK 4] Implementasi Graphical User Interface (GUI):**
    * **Deskripsi Singkat:** Video ini menampilkan implementasi GUI pada game, termasuk keberadaan *cover* game, serta penggunaan elemen UI standar seperti *image*, *text*, dan *button* yang disesuaikan dengan kebutuhan game.
    * **Tonton Video:** [[LINK_VIDEO_YOUTUBE_SUB_CPMK_4](https://youtu.be/3wDroKOC50I)]
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Detail Teknis & Fitur Proyek
Berikut adalah rincian lebih lanjut mengenai aspek-aspek teknis dan fitur-fitur yang ada di dalam game ini:

### SubCPMK 1: Level Design & Asset Integration
* **Tema Level:** pegunungan dan kota futuristik
* **Terrain:** Implementasi terrain mencakup pohon, rumput, untuk tekstur : tanah, aspal, gunung, dan sungai yang mengalir.
* **Skybox:** Menggunakan procedural skybox, cubemap yang mendukung tema visual.
* **Objek 3D:** Berbagai objek 3D ditempatkan secara strategis di terrain untuk memperkaya lingkungan game : Mobil, gedung

### SubCPMK 2: Playable Game & Logic
* **Karakter 3D:** Menggunakan karakter player [pikochan] dari Asset Store dengan sistem pergerakan maju, mundur, kiri, kanan.
* **Kamera:** Set ke **Third Person Shooter (TPS)** untuk pengalaman bermain yang imersif.
* **Atribut Karakter:** Poin dan Nyawa, keduanya memiliki nilai awal/maksimal 100.
* **Sistem Koin:**
    * **5 jenis koin 3D:** Merah, Kuning, Hijau, Biru, Hitam (diambil dari Asset Store).
    * **Jumlah:** Merah=3, Kuning=3, Hijau=2, Biru=2, Hitam=7, tersebar acak di terrain.
    * **Interaksi Koin:**
        * **Merah:** Menambah 20 poin.
        * **Kuning:** Menambah 30 poin & membuat semua lampu menyala.
        * **Hijau:** Menambah 100 poin.
        * **Biru:** Menambah 10 nyawa.
        * **Hitam:** Mengurangi 20 nyawa & mematikan semua lampu.
* **UI Text:** Tampilan real-time poin dan nyawa pada antarmuka pengguna.

### SubCPMK 3: Universal Render Pipeline (URP)
* **Penerapan:** Game ini mengaplikasikan Universal Render Pipeline (URP) untuk optimasi grafis dan visual yang konsisten.
* **Konfigurasi:** Menggunakan URP (Universal Render Pipeline) karena konfigurasi ini ringan untuk game terrain dasar seperti ini serta memiliki performa lintas platform. Dari segi visual pencahayaannya cukup di Real-time lighting dasar yang memiliki material Shader Graph sederhana.

### SubCPMK 4: Graphical User Interface (GUI)
* **Cover Game:** Terdapat *cover* game sebagai tampilan awal yang menarik bagi pemain.
* **Elemen UI:** Penggunaan elemen UI dasar seperti *image*, *text*, dan *button* diimplementasikan untuk navigasi, menampilkan informasi, dan interaksi pemain. Seperti adanya Button Start, Quit, display score/health, Restart [mulai bermain lagi ketika game over(nyawa habis atau waktu habis)]
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Kontak
Terima kasih atas waktu Anda meninjau proyek ini. Jika ada pertanyaan lebih lanjut atau ingin berdiskusi, silakan hubungi saya:

* **LinkedIn:** https://www.linkedin.com/in/linda-fazrie
* **Email:** fazriesantoso02@gmail.com
