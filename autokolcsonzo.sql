-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Már 09. 19:54
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `autokolcsonzo`
--
CREATE DATABASE IF NOT EXISTS `autokolcsonzo` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `autokolcsonzo`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `autok`
--

CREATE TABLE `autok` (
  `Id` int(11) NOT NULL,
  `marka` longtext NOT NULL,
  `tipus` longtext NOT NULL,
  `ev` int(11) NOT NULL,
  `arnaponta` decimal(65,30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `autok`
--

INSERT INTO `autok` (`Id`, `marka`, `tipus`, `ev`, `arnaponta`) VALUES
(1, 'Nissan', 'Micra', 2008, 400000.000000000000000000000000000000),
(2, 'Toyota', '4869616365', 1999, 800000.000000000000000000000000000000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kolcsonzesek`
--

CREATE TABLE `kolcsonzesek` (
  `Id` int(11) NOT NULL,
  `ugyfelid` int(11) NOT NULL,
  `autoid` int(11) NOT NULL,
  `kezdes` datetime(6) NOT NULL,
  `vegzes` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `kolcsonzesek`
--

INSERT INTO `kolcsonzesek` (`Id`, `ugyfelid`, `autoid`, `kezdes`, `vegzes`) VALUES
(1, 2, 1, '2025-03-09 19:36:52.000000', '2025-03-12 19:36:52.000000'),
(2, 1, 2, '2025-03-03 19:36:52.000000', '2025-03-09 19:36:52.000000');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugyfelek`
--

CREATE TABLE `ugyfelek` (
  `Id` int(11) NOT NULL,
  `Nev` longtext NOT NULL,
  `email` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `ugyfelek`
--

INSERT INTO `ugyfelek` (`Id`, `Nev`, `email`) VALUES
(1, 'Janos', 'janos@gmail.com'),
(2, 'Irma', 'irma@gmail.com');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20250309182553_keszits', '8.0.13');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `autok`
--
ALTER TABLE `autok`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `kolcsonzesek`
--
ALTER TABLE `kolcsonzesek`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_kolcsonzesek_autokId` (`autoid`),
  ADD KEY `IX_kolcsonzesek_ugyfelekId` (`ugyfelid`);

--
-- A tábla indexei `ugyfelek`
--
ALTER TABLE `ugyfelek`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `autok`
--
ALTER TABLE `autok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `kolcsonzesek`
--
ALTER TABLE `kolcsonzesek`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `ugyfelek`
--
ALTER TABLE `ugyfelek`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `kolcsonzesek`
--
ALTER TABLE `kolcsonzesek`
  ADD CONSTRAINT `FK_kolcsonzesek_autok_autokId` FOREIGN KEY (`autoid`) REFERENCES `autok` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_kolcsonzesek_ugyfelek_ugyfelekId` FOREIGN KEY (`ugyfelid`) REFERENCES `ugyfelek` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
