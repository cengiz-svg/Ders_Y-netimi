CREATE DATABASE ders_yonetimi;
USE ders_yonetimi;

CREATE TABLE bolum (
    bolum_id INT PRIMARY KEY,
    bolum_ad VARCHAR(100) NOT NULL
);

CREATE TABLE ogretmen (
    ogretmen_id INT PRIMARY KEY,
    ogretmen_ad VARCHAR(50) NOT NULL,
    ogretmen_soyad VARCHAR(50) NOT NULL,
    ogretmen_email VARCHAR(100),
    bolum_id INT,
    FOREIGN KEY (bolum_id) REFERENCES bolum(bolum_id) -- öğretmenin hangi bölüme ait olduğuna ulaşmak için
);

CREATE TABLE ogrenci (
    ogrenci_id INT PRIMARY KEY,
    ogrenci_ad VARCHAR(50) NOT NULL,
    ogrenci_soyad VARCHAR(50) NOT NULL,
    ogrenci_email VARCHAR(100) UNIQUE ,
    bolum_id INT,
    danisman_id INT,
    FOREIGN KEY (bolum_id) REFERENCES bolum(bolum_id), -- öğrencinin okuduğu bölüme ulaşmak için
    FOREIGN KEY (danisman_id) REFERENCES ogretmen(ogretmen_id) -- öğrencinin o bölümdeki danışmanı 
);

CREATE TABLE dersler (
    ders_id INT PRIMARY KEY,
    ders_ad VARCHAR(100) NOT NULL UNIQUE ,
    kredi INT NOT NULL CHECK(kredi>0) ,
    akts INT NOT NULL CHECK(akts>0) , 
    ogretmen_id INT,
    bolum_id INT,
    FOREIGN KEY (ogretmen_id) REFERENCES ogretmen(ogretmen_id), -- dersi veren öğretmene ulaşmak
    FOREIGN KEY (bolum_id) REFERENCES bolum(bolum_id) -- dersin hangi bölüme ait olduğunu bulmak
);

CREATE TABLE ders_kayit (
    ogrenci_id INT,
    ders_id INT,
    yil INT  NOT NULL DEFAULT 2025,
    donem ENUM('Güz', 'Bahar'), -- burada enum kullanarak sadece güz ve baharda bu işlemin yapılacağını belirtir
    vize INT,
    final INT, -- bu notları tutmamızın sebebi ders yönetim sistemibdeki öğrencilerin akademik ilerleyişini takip etmek
    PRIMARY KEY (ogrenci_id, ders_id), --  aynı öğrenci aynı dersi aynı yıl ve dönemde sadece bir kez alabilir
    FOREIGN KEY (ogrenci_id) REFERENCES ogrenci(ogrenci_id), -- ders kaydı bir öğrenciye ait olmalı
    FOREIGN KEY (ders_id) REFERENCES dersler(ders_id) -- her dersin kaydı bir derse ait olacak
);
INSERT INTO bolum (bolum_id, bolum_ad) VALUES
(1, 'Bilgisayar Mühendisliği'),
(2, 'Elektrik-Elektronik Mühendisliği'),
(3, 'Makine Mühendisliği');

INSERT INTO ogretmen (ogretmen_id, ogretmen_ad, ogretmen_soyad, ogretmen_email, bolum_id) VALUES
(1001, 'Hüseyin', 'Işık', 'huseyin.isik@example.com', 1),
(1002, 'Ayşegül', 'Kaya', 'aysegul.kaya@example.com', 1),
(1003, 'Mustafa', 'Lale', 'mustafa.lale@example.com', 2),
(1004, 'Melike', 'Mert', 'melike.mert@example.com', 3);

INSERT INTO ogrenci (ogrenci_id, ogrenci_ad, ogrenci_soyad, ogrenci_email, bolum_id, danisman_id) VALUES
(2001, 'Deniz', 'Arslan', 'deniz.arslan@example.com', 1, 1001),
(2002, 'Ege', 'Baran', 'ege.baran@example.com', 1, 1002),
(2003, 'Lara', 'Çakır', 'lara.cakir@example.com', 2, 1003),
(2004, 'Emir', 'Duman', 'emir.duman@example.com', 2, 1003),
(2005, 'Selma', 'Erdoğan', 'selma.erdogan@example.com', 3, 1004),
(2006, 'Baran', 'Fidan', 'baran.fidan@example.com', 1, 1001),
(2007, 'Derya', 'Güneş', 'derya.gunes@example.com', 3, 1004),
(2008, 'Kerem', 'Hazar', 'kerem.hazar@example.com', 2, 1003);

INSERT INTO dersler (ders_id, ders_ad, kredi, akts, ogretmen_id, bolum_id) VALUES
(301, 'Veri Tabanı Yönetimi', 4, 6, 1001, 1),
(302, 'Algoritma ve Programlama', 3, 5, 1002, 1),
(303, 'Matematik I', 4, 6, 1003, 2),
(304, 'Fizik I', 3, 4, 1003, 2),
(305, 'Elektrik Devreleri', 4, 6, 1003, 2),
(306, 'Yazılım Mühendisliği', 3, 5, 1002, 1),
(307, 'Makine Elemanları', 4, 6, 1004, 3),
(308, 'Robotik ve Otomasyon', 3, 5, 1004, 3);

INSERT INTO ders_kayit (ogrenci_id, ders_id, yil, donem, vize, final) VALUES
(2001, 301, 2025, 'Güz', 75, 85),
(2001, 302, 2025, 'Bahar', 80, 90),
(2002, 301, 2025, 'Bahar', 70, 78),
(2002, 306, 2025, 'Güz', 88, 92),
(2003, 303, 2025, 'Güz', 65, 70),
(2003, 304, 2025, 'Bahar', 72, 76),
(2004, 305, 2025, 'Güz', 60, 68),
(2004, 304, 2025, 'Bahar', 75, 80),
(2005, 307, 2025, 'Bahar', 85, 90),
(2006, 302, 2025, 'Güz', 78, 82),
(2006, 306, 2025, 'Bahar', 88, 91),
(2007, 307, 2025, 'Güz', 70, 75),
(2008, 303, 2025, 'Bahar', 82, 86),
(2008, 305, 2025, 'Güz', 77, 80);


