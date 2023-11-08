﻿CREATE DATABASE DONARE
CREATE TABLE BOALA(
   BOALA_ID INT PRIMARY KEY,
   NUME VARCHAR(100),
   SIMPTOME_ID INT,
   DATA_CREARII DATETIME,
   DATA_ULTIMII_SCHIMBARI DATETIME
   FOREIGN KEY (SIMPTOME) REFERENCES STAREA(STARE_ID)
)

CREATE TABLE STAREA (
   STARE_ID INT PRIMARY KEY,
   SIMPTOME VARCHAR(100),
   DATA_CREARII DATETIME,
   DATA_ULTIMII_SCHIMBARI DATETIME
)

CREATE TABLE DONOR(
   DONOR_ID INT PRIMARY KEY, 
   NUME VARCHAR(100),
   PRENUME VARCHAR(100),
   ADRESA VARCHAR(100),
   NR_TEL VARCHAR(100),
   GRUPA_SANGE VARCHAR(3),
   DATA_CREARII DATETIME,
   DATA_ULTIMII_SCHIMBARI DATETIME

)

CREATE TABLE PACIENT (
   PACIENT_ID INT PRIMARY KEY,
   NUME VARCHAR(100),
   PRENUME VARCHAR(100),
   AN_NASTERE DATE,
   BLOOD_TYPE VARCHAR(3),
   DATA_CREARII DATETIME,
   DATA_ULTIMII_SCHIMBARI DATETIME,
   BOALA_ID INT,
   STARE_ID INT,
   DONOR_ID INT,
   FOREIGN KEY (BOALA_ID ) REFERENCES BOALA(BOALA_ID),
   FOREIGN KEY (STARE_ID) REFERENCES STAREA(STARE_ID),
   FOREIGN KEY (DONOR_ID ) REFERENCES DONOR(DONOR_ID)
)

INSERT INTO STAREA (STARE_ID, SIMPTOME, DATA_CREARII, DATA_ULTIMII_SCHIMBARI)
VALUES
(1, 'AMETEALA', GETDATE(), GETDATE()),
(2, 'VOMA', GETDATE(), GETDATE()),
(3, 'OBOSEALA RAPIDA', GETDATE(), GETDATE()),
(4, 'DURERI CARDIACE', GETDATE(), GETDATE()),
(5, 'SCHIMBAREA CULORII PIELII', GETDATE(), GETDATE()),
(6, 'FEBRA', GETDATE(), GETDATE()),
(7, 'SCADEREA IN GREUTATE', GETDATE(), GETDATE());

INSERT INTO BOALA (BOALA_ID, NUME, SIMPTOME_ID, DATA_CREARII, DATA_ULTIMII_SCHIMBARI)
VALUES
(1, 'LUCEMIE', 1, GETDATE(), GETDATE()),
(2, 'LEUCEMIE',2, GETDATE(), GETDATE()),
(3, 'CIROZA HEPATICA',7, GETDATE(), GETDATE()),
(4, 'SCLEROZA',6, GETDATE(), GETDATE()),
(5, 'SCLEROZA',3, GETDATE(), GETDATE()),
(6, 'WILSON',5, GETDATE(), GETDATE())

INSERT INTO DONOR (DONOR_ID, NUME, PRENUME, ADRESA, NR_TEL, GRUPA_SANGE, DATA_CREARII, DATA_ULTIMII_SCHIMBARI)
VALUES
(1, 'Maria', 'Popescu', 'Strada Florilor, Bucuresti, România', '0721-123-456', 'I+', GETDATE(), GETDATE()),
(2, 'Ion', 'Ionescu', 'Bulevardul Libertătii, Cluj-Napoca, Romania', '0722-987-654', 'II-', GETDATE(), GETDATE()),
(3, 'Elena', 'Georgescu', 'Aleea Păcii, Timisoara, România', '0723-555-888', 'I-', GETDATE(), GETDATE()),
(4, 'Mihai', 'Constantin', 'Strada Principală, Iasi, România', '0724-111-222', 'II+', GETDATE(), GETDATE()),
(5, 'Ana', 'Dumitrescu', 'Bulevardul Unirii, Constanta, România', '0725-333-444', 'IV+', GETDATE(), GETDATE())

INSERT INTO PACIENT (PACIENT_ID, NUME, PRENUME, AN_NASTERE, BLOOD_TYPE, DATA_CREARII, DATA_ULTIMII_SCHIMBARI, BOALA_ID, STARE_ID, DONOR_ID)
VALUES
(1, 'Alex', 'Popescu', '1990-05-15', 'I+', GETDATE(), GETDATE(), 1, 1, 1),
(2, 'Andreea', 'Ionescu', '1985-07-20', 'II-', GETDATE(), GETDATE(), 2, 2, 2),
(3, 'Mihai', 'Georgescu', '1978-03-10', 'I+', GETDATE(), GETDATE(), 3, 3, NULL),
(4, 'Elena', 'Constantin', '1995-12-05', 'I-', GETDATE(), GETDATE(), 4, 4, 3),
(5, 'Ana', 'Dumitrescu', '1992-08-02', 'IV+', GETDATE(), GETDATE(), 5, 5, 5)

--Afișați toate bolile și simptomele asociate lor. 
--Utilizați comanda Join pentru a conecta tabelele "BOALA" și "STAREA" pentru a obține aceste informații.
SELECT BOALA.NUME AS NUME_BOALA, STAREA.SIMPTOME AS SIMPTOME
FROM BOALA
INNER JOIN STAREA ON BOALA.SIMPTOME_ID = STAREA.STARE_ID

--Să extindeți interogarea existentă pentru a obține numărul total de pacienți pentru fiecare boală,
--Apoi, ordonați rezultatele în ordine descrescătoare a numărului de pacienți.
SELECT B.NUME AS NumeBoala, COUNT(P.PACIENT_ID) AS NumarPacienti
FROM BOALA B
LEFT JOIN PACIENT P ON B.BOALA_ID = P.BOALA_ID
GROUP BY B.NUME
HAVING COUNT(P.PACIENT_ID) <= 2
ORDER BY NumarPacienti DESC;

--Utilizați comanda UPDATE pentru a actualiza tabela "STAREA" pentru înregistrarea cu "STARE_ID" 4, 
--schimbând simptomele la "LESIN" și actualizând data ultimei modificări la data curentă 
UPDATE STAREA
SET SIMPTOME = 'LESIN', DATA_ULTIMII_SCHIMBARI = GETDATE()
WHERE STARE_ID = 4