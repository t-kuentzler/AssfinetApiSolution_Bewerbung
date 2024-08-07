# Assfinet.InitialImporter.Api

## Beschreibung
Die Software ruft alle Kunden, Vertrags und Vertragssparten Daten von der Assfinet Api ab.
Diese werden dann in der eigenen lokalen Datenbank gespeichert.
Das soll nur einmalig Initial ausgeführt werden.
Mit der Software Assfinet.DailyUpdate werden die täglichen Änderungen synchronisiert.

Für das Hinzufügen neuer Sparten muss der Typ als Enum in 'SpartenTypen' gespeichert werden.