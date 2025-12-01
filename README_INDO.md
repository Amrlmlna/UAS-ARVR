# Sistem Speaker AR - Pengalaman Audio Augmented Reality

## Gambaran Umum Proyek

Proyek ini adalah aplikasi sistem speaker Augmented Reality (AR) yang dikembangkan menggunakan Unity dan SDK Vuforia. Aplikasi ini memungkinkan pengguna untuk menempatkan speaker virtual di lingkungan nyata menggunakan target gambar dan mengontrol pemutaran musik melalui tombol sentuh interaktif. Sistem ini dapat memutar beberapa trek audio secara bersamaan di berbagai model speaker, menciptakan pengalaman audio yang imersif dalam augmented reality.

## Arsitektur

### Struktur Proyek

```
My Project/
├── Assets/                 # Aset utama proyek
│   ├── Editor/             # Script dan alat khusus editor
│   ├── HQ Acoustic system/ # Model 3D dan material untuk sistem speaker
│   ├── Materials/          # Aset material
│   ├── Prefabs/            # Objek game yang telah dibuat sebelumnya
│   │   └── Ghost Models/   # Model visual untuk umpan balik penempatan
│   ├── Resources/          # Aset yang dimuat saat runtime
│   │   └── Music/          # File audio
│   ├── Scenes/             # File scene Unity
│   ├── Scripts/            # File script C#
│   └── StreamingAssets/    # Aset disalin ke build tanpa diproses
├── Library/                # Data proyek yang dibuat oleh Unity
├── Logs/                   # Log build dan runtime
├── Packages/               # Paket dan dependensi proyek
├── ProjectSettings/        # Pengaturan konfigurasi proyek
├── QCAR/                   # Data target AR Vuforia
├── Temp/                   # File sementara
└── UserSettings/           # Pengaturan spesifik pengguna
```

### Komponen Utama

#### Script

- **ARSpeakerManager.cs**: Sistem kontrol audio utama yang mengelola pemutaran musik di berbagai speaker
- **SimpleTouchButton.cs**: Menangani interaksi sentuh untuk fungsionalitas putar/jeda

#### Scene

- **SampleScene.unity**: Scene utama dengan tiga target gambar AR (Speaker1, Speaker2, Speaker3) dan speaker virtual

#### Aset dan Prefab

- **HQ Acoustic System**: Model 3D dari peralatan akustik berkualitas tinggi
- **Ghost Models**: Placeholder visual yang muncul selama penempatan speaker AR
- **Prefabs**: Objek speaker yang telah dikonfigurasi (Mid-Range Speaker, Speaker Tower, Subwoofer, dll.)

#### Sumber Daya Audio

- **Folder Music**: Berisi file audio untuk pemutaran (In Dreamland, Middle C, Orb Sound, dll.)

## Informasi Folder Terperinci

### Folder Assets

Directory konten utama yang berisi semua aset proyek, script, dan sumber daya.

#### Editor

Berisi ekstensi editor Unity dan alat khusus untuk alur kerja pengembangan.

#### HQ Acoustic System

Folder ini berisi model 3D dari peralatan akustik berkualitas tinggi:

- **Model FBX**: Amplifier.FBX, Satellite_center.FBX, Satellite_hight.FBX, Satellite_low.FBX, Subwoofer.FBX
- **Prefab**: Versi prefab dari setiap model siap digunakan di scene
- **Tekstur**: Peta tekstur difus, normal, dan specular untuk material realistis

#### Materials

Berisi aset material untuk rendering visual:

- **Dark.mat**: Material berwarna gelap
- **Deep Black.mat**: Material hitam pekat
- **Glass.mat**: Material transparan kaca
- **Glow.mat**: Material berpendar emisi
- **Temporary Material.mat**: Material sementara

#### Prefabs

Objek game yang telah dikonfigurasi yang dapat diinstansiasi di scene:

- **Ghost Models**: Objek visual untuk umpan balik penempatan AR
  - Ghost Midrange, Ghost Speaker Tower, Ghost Subwoofer, Ghost Tweeter
- **Elemen Interaktif**:
  - Edit Speaker UI, Music Queue Menu, Now Playing Menu
- **Objek Speaker**:
  - Mid-Range Speaker, Speaker Tower, Subwoofer, Tweeter
- **Elemen UI**: Prefab Orb, Window

#### Resources

Aset yang dimuat saat runtime:

- **Music**: Berisi semua file audio yang digunakan dalam aplikasi
  - In Dreamland (Default Song).mp3
  - Middle C.mp3
  - Orb Sound.mp3
  - phaseSound.mp3
  - pop.mp3
  - Subwoofer Sound.mp3
  - White Noise.mp3

#### Scenes

Berisi scene Unity utama:

- **SampleScene.unity**: Scene aplikasi AR utama dengan kamera, lampu, dan tiga target gambar

#### Scripts

Script logika aplikasi:

- **ARSpeakerManager.cs**: Sistem manajemen audio utama
- **SimpleTouchButton.cs**: Penanganan interaksi sentuh

#### StreamingAssets

Berisi aset yang disalin ke build tanpa diproses, biasanya digunakan untuk file data atau aset yang perlu tetap dalam format aslinya.

### Folder Library

Folder yang dibuat oleh Unity berisi data build proyek dan informasi cache. Folder ini sebaiknya tidak disimpan ke kontrol versi.

### Folder Logs

Berisi log build dan runtime untuk debugging.

### Folder Packages

Berisi dependensi paket Unity termasuk:

- **com.ptc.vuforia.engine-11.4.4.tgz**: SDK AR Vuforia
- **manifest.json**: Dependensi dan versi paket
- **packages-lock.json**: Versi paket yang terkunci

### Folder ProjectSettings

Berisi semua pengaturan spesifik proyek, termasuk:

- **VuforiaConfiguration.asset**: Pengaturan dan kunci lisensi Vuforia AR
- **AudioManager.asset**: Konfigurasi sistem audio
- **GraphicsSettings.asset**: Pengaturan rendering grafis
- **InputManager.asset**: Konfigurasi sistem input
- Berbagai pengaturan mesin Unity lainnya

### Folder QCAR

Berisi data target AR Vuforia dan file konfigurasi.

### Folder Temp dan UserSettings

File sementara dan pengaturan spesifik pengguna masing-masing. Ini biasanya dikecualikan dari kontrol versi.

## Fungsionalitas Script

### ARSpeakerManager.cs

Script kontrol audio utama yang:

- Memuat trek musik dari folder Resources/Music saat runtime
- Mengelola status pemutaran (putar/jeda) di semua speaker aktif
- Mensinkronkan posisi trek saat beralih putar/jeda
- Mencari semua GameObject yang diberi tag "Speakers" untuk mengontrol pemutaran audio
- Menjaga waktu trek untuk memastikan sinkronisasi pemutaran di berbagai speaker

### SimpleTouchButton.cs

Script interaksi sederhana yang:

- Mendeteksi input mouse/sentuh pada objek 3D
- Memberikan umpan balik visual dengan memindahkan tombol saat ditekan
- Memanggil ARSpeakerManager untuk beralih pemutaran musik
- Berkomunikasi dengan manajer musik untuk mengontrol audio

## Platform dan Informasi Build

Proyek ini dikonfigurasi untuk deployment Android:

- **SDK Minimum**: API 29 (Android 10)
- **Arsitektur Target**: ARM64
- **Identitas Aplikasi**: com.DefaultCompany.Myproject
- **Versi Bundle**: 0.1

Proyek ini menyertakan dua file APK (UAS.apk, UAStes.apk) yang menunjukkan build yang telah selesai untuk deployment Android.

## Kemampuan AR

Aplikasi ini menggunakan SDK Vuforia AR versi 11.4.4 dengan:

- Pengenalan target gambar untuk penempatan speaker
- Tiga target gambar yang ditentukan (Speaker1, Speaker2, Speaker3)
- Visualisasi model hantu untuk umpan balik penempatan
- Rendering 3D real-time dari model speaker pada target yang dikenali
- Kamera AR dengan rendering latar belakang

## Sistem Audio

Implementasi audio menampilkan:

- Pemuatan runtime file audio dari folder Resources
- Pemutaran sinkron di berbagai speaker
- Pelacakan posisi untuk menjaga sinkronisasi
- Dukungan untuk berbagai jenis speaker dengan karakteristik audio berbeda

## Fitur Aplikasi

1. **Audio Speaker Multi-AR**: Menempatkan beberapa speaker virtual di ruang nyata
2. **Kontrol Sentuh**: Tombol interaktif untuk fungsionalitas putar/jeda
3. **Pemutaran Sinkron**: Trek audio tetap sinkron di semua speaker
4. **Pemuatan Musik Runtime**: Memuat musik secara dinamis dari folder Resources
5. **Umpan Balik Visual**: Model hantu memberikan panduan penempatan
6. **Pengalaman Audio 3D**: Audio spasial imersif dalam augmented reality

## Dependensi Teknis

- Unity Engine (versi berdasarkan template yang terpasang)
- Vuforia SDK 11.4.4
- Dukungan Build Android
- ARCore (untuk fungsionalitas AR Android)

## Output Build

Proyek ini menyertakan dua file APK:

- **UAS.apk**: Build proyek akhir
- **UAStes.apk**: Build uji atau pengembangan

## Catatan Pengembangan

Aplikasi ini dikembangkan dengan fokus pada penciptaan pengalaman audio AR yang imersif. Kode ini menyertakan komentar bahasa Indonesia yang menunjukkan bahwa proyek ini dikembangkan untuk konteks akademik Indonesia. Target AR dikonfigurasi untuk mengenali marker fisik spesifik untuk penempatan speaker.

---

## Peran Tim untuk Tugas Akhir

1. **Project Lead (Koordinator Tim - Amirul Maulana - F55123039)**

   - Bertanggung jawab atas manajemen proyek secara keseluruhan dan koordinasi
   - Memastikan semua anggota tim bekerja pada tugas yang ditetapkan
   - Mengoordinasikan antara berbagai aspek pengembangan
   - Mengelola jadwal proyek dan target hasil
   - Menangani komunikasi dengan dosen dan pemangku kepentingan

2. **AR Developer (Spesialis Augmented Reality - Anggita Setiawati - F55123092)**

   - Implementasi dan pemeliharaan fungsionalitas Vuforia AR
   - Konfigurasi target gambar dan sistem pelacakan
   - Optimasi kinerja AR dan akurasi pelacakan
   - Menangani tantangan khusus AR seperti estimasi pencahayaan dan deteksi bidang
   - Pengujian fungsionalitas AR pada berbagai perangkat dan kondisi pencahayaan

3. **Audio Systems Engineer (Insinyur Sistem Audio - Sri Aswanti - F55123075)**

   - Mengembangkan dan memelihara sistem pemutaran audio
   - Implementasi sinkronisasi antara beberapa speaker
   - Optimasi pemuatan dan streaming audio
   - Memastikan kualitas audio dan kinerja di berbagai perangkat
   - Mengelola format file audio dan kompresi

4. **UI/UX Designer (Desainer UI/UX - Siti Fajriah - F55121028)**

   - Merancang antarmuka pengguna untuk aplikasi AR
   - Membuat kontrol sentuh intuitif untuk interaksi speaker
   - Mengembangkan sistem umpan balik visual untuk interaksi AR
   - Fokus pada pengalaman pengguna dan kemudahan penggunaan
   - Menerapkan pedoman desain visual dan konsistensi

5. **3D Model Specialist (Spesialis Model 3D - Anugrah Ahmad Wiranto - F55123069)**

   - Membuat dan mengoptimalkan model 3D untuk speaker dan elemen UI
   - Memastikan model 3D dioptimalkan untuk kinerja AR mobile
   - Implementasi optimasi material dan tekstur
   - Bekerja pada efek visual seperti model hantu dan animasi
   - Mengelola pipeline aset 3D dan kualitas

6. **Quality Assurance & Testing Lead (Pemimpin Jaminan Kualitas & Pengujian - Adelia nur Sakinah - F55121074)**
   - Mengembangkan dan mengeksekusi rencana pengujian untuk aplikasi AR
   - Menguji fungsionalitas di berbagai perangkat dan platform
   - Mengidentifikasi dan mendokumentasikan bug dan masalah
   - Melakukan pengujian pengalaman pengguna dan mengumpulkan umpan balik
   - Memastikan stabilitas aplikasi dan optimasi kinerja
