# CSharpProject

Smart City Manager — C# Console Application

## Description du projet

Application console C# simulant la gestion d'une ville intelligente. Elle permet de :

- **Gérer des points d'intérêt** (Campus, Monuments historiques) avec calcul de distance et liens Google Maps
- **Gérer une flotte de véhicules** (Voiture, Camion, Voiture hybride) avec simulation de conduite
- **Créer et suivre des trajets** avec estimation de durée et suivi temporel

---

## Architecture du projet

```
SmartCity/
│
├── Interfaces/
│   ├── IElectricCar.cs         # Interface : recharge batterie
│   └── IThermalCar.cs          # Interface : ravitaillement carburant
├── Models/
│   ├── PointOfInterest.cs      # Classe de base (lat, lon, distance, URL Maps)
│   ├── Campus.cs               # Dérivée : capacité personnes
│   ├── HistoricalMonument.cs   # Dérivée : année de construction
│   ├── Vehicle.cs              # Classe abstraite Gestion de l'energie du vehicule
│   ├── Vehicles.cs             # Classe abstraite de Personbalisation
│   └── Trip.cs                 # Trajet entre deux lieux avec durée estimée
├── Services/
│   └── CityService.cs          # Gestion des collections (List, Dictionary, HashSet)
├── UI/
│   ├── AddCar.cs                       # Affichage : Ajouts de véhicules
│   ├── AddPointOfInterestMenu.cs       # Affichage : Ajouts de point d'interes
│   ├── AddTrip.cs                      # affichage : Ajouts des voyage
│   ├── CalcularoDistence.cs            # Estimation du temps de voyage 
│   ├── DisplayAndErrorGestion.cs       # Affichage : des message utilisateur
│   ├── DisplayCarMenu.cs               # Affichage : Liste véhicules
│   ├── DisplayDeplacement.cs           # Affichage : Liste des trajes
│   ├── DisplayPointOfInterestMenu.cs   # Affichage : Liste des lieux
│   ├── PrincipaleMenu.cs               # Affichage : Fusion de tous les menu
│   └── Menu.cs                         # Affichage du menu principal interactif
│
├── Program.cs                  # Lancement
└── SmartCity.csproj
```

---

## Instructions d'exécution

### Prérequis
- [.NET 10 SDK] https://dotnet.microsoft.com/fr-fr/download

### Lancer l'application
```bash
cd SmartCity
dotnet run
```

---

## Menu principal

| Option | Action |
|--------|--------|
| 1 | Ajouter un point d'intérêt (Campus ou Monument) |
| 2 | Ajouter un véhicule (Voiture, Camion, Hybride) |
| 3 | Afficher tous les véhicules |
| 4 | Afficher tous les lieux |
| 5 | Calculer la distance entre deux lieux |
| 6 | Simuler accélération / freinage (+ recharge HybridCar) |
| 7 | Créer un trajet (véhicule + départ + arrivée + date) |
| 8 | Afficher tous les trajets |
| 9 | Quitter |

---

## Choix techniques

### Programmation orientée objet
- **Héritage** : `Campus` et `HistoricalMonument` héritent de `PointOfInterest` ; `Car`, `Truck`, `HybridCar` héritent de la classe abstraite `Vehicle`
- **Polymorphisme** : `ToString()` redéfini dans chaque classe, `Accelerate()` surchargé dans `HybridCar`
- **Interfaces** : `IThermalCar` et `IElectricCar` implémentées par `HybridCar`
- **Encapsulation** : propriétés C# avec getters/setters, vitesse protégée en écriture

### Collections (dans `DataManager`)
| Collection | Usage |
|------------|-------|
| `List<Vehicle>` | Stockage des véhicules (accès par index) |
| `List<PointOfInterest>` | Stockage des lieux |
| `List<Trip>` | Stockage des trajets |
| `Dictionary<string, string>` | Association marque → type de véhicule |
| `HashSet<string>` | Évite les doublons de noms de lieux |

### Calcul de distance
Par défaut, utiliser une distance simplifiée (euclidienne). Distance simplifiée :  √((lat2 - lat1)² + (lon2 - lon1)²) 

### Gestion HybridCar
HybridCar implémente IThermalCar et IElectricCar. Lors de l’accélération : • Priorité à la batterie  • Puis carburant si batterie vide
• IThermalCar :  Refuel(double amount)  , FuelLevel  
• IElectricCar :  Recharge (double amount)  , BatteryLevel 

### Gestion Car
Car implémente IThermalCar . Lors de l’accélération : Utilisation carburant si vide fin du trajets
• IThermalCar :  Refuel(double amount)  , FuelLevel  
