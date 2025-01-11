This is a "Dive Into World of Pokémon" Web project that based on Blazor web app, MSSQL Database and ASP.Net. This project purpose is basically give information about world-famous Pokémon Universe. In this website you can view and edit Pokémon species. In this card shaped view you can see Pokémon’s image, region, health, speed, attack, abilities, height, weight and level. You can see trainers and their bags that consist items. You can see elemental based moves and their combinations with trainers and Pokémons. Also you can see total Pokémon, Trainer and Region count. In Admin page, you can create, read, update and delete all of these elements. Additionally you can evolve Pokémon’s if its level is higher than 17. When you evolve it, its name changes to evolved form’s name. In Pokémon Statistics page, you can see 2 pie charts that show Pokémon distribution by region and  item distribution by region.
Implementation Steps:

1-	Create a database in MSSQL Server Management Studio with query that given below.

CREATE DATABASE POKEMON;
CREATE TABLE Region (
    RegionId INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing PK
    RegionName VARCHAR(20) NOT NULL,        
    Number_of_pokemons INT,
    Region_type VARCHAR(20)
);
CREATE TABLE Trainer (
    TrainerId INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing PK
    Trainer_name VARCHAR(35),
    Trainer_class VARCHAR(20),
    Team_Badges VARCHAR(25) DEFAULT 'STARTER',
    Gender CHAR(1) NOT NULL
);
CREATE TABLE Move (
    MoveId INT PRIMARY KEY IDENTITY(1,1), -- Auto-incrementing PK
    Move_name VARCHAR(25),
    Description VARCHAR(35),
    Types VARCHAR(20),
    overallStat INT
);
CREATE TABLE Item (
    ItemId INT PRIMARY KEY IDENTITY(1,1), 
    ItemName VARCHAR(25) NOT NULL,        
    Effect VARCHAR(30),
    Type_of_item VARCHAR(20) NOT NULL,
    RegionId INT,                         
    FOREIGN KEY (RegionId) REFERENCES Region (RegionId)
);
CREATE TABLE Pokemon (
    PokemonId INT PRIMARY KEY IDENTITY(1,1), 
    Pokemon_name VARCHAR(25),
    RegionId INT,                              
    Health INT,
    Speed INT,
    Attack INT,
    Abilities VARCHAR(20),
    Height_weight DECIMAL(5, 2),
    Level INT DEFAULT 1,                      
    FOREIGN KEY (RegionId) REFERENCES Region (RegionId)
);
CREATE TABLE Carries (
    Id INT PRIMARY KEY IDENTITY(1,1),          
    TrainerId INT NOT NULL,                    
    ItemId INT NOT NULL,                        
    UNIQUE (TrainerId, ItemId),                 
    FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId), 
    FOREIGN KEY (ItemId) REFERENCES Item(ItemId)
);
CREATE TABLE Evolution (
    Id INT PRIMARY KEY IDENTITY(1,1),         
    PokemonId INT NOT NULL,                    
    Evolved_form VARCHAR(25),
    Evolution_condition VARCHAR(55),
    UNIQUE (PokemonId, Evolved_form),             
    FOREIGN KEY (PokemonId) REFERENCES Pokemon(PokemonId)
);
CREATE TABLE USES (
    Id INT PRIMARY KEY IDENTITY(1,1),          
    TrainerId INT NOT NULL,                     
    MoveId INT NOT NULL,                        
    PokemonId INT NOT NULL,                     
    UNIQUE (TrainerId, MoveId, PokemonId),     
    FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId),
    FOREIGN KEY (MoveId) REFERENCES Move(MoveId),
    FOREIGN KEY (PokemonId) REFERENCES Pokemon(PokemonId)
);

2-	Open a new query in your MSSQL Server Management Studio and insert the data given below.
INSERT INTO Trainer (Trainer_name, Trainer_class, Team_Badges, Gender)
VALUES
('Ash', 'Pokémon Trainer', 'Thunder Badge', 'M'),
('Misty', 'Water Gym Leader', 'Cascade Badge', 'F'),
('Brock', 'Rock Gym Leader', 'Boulder Badge', 'M'),
('Cynthia', 'Champion', 'Dragon Badge', 'F'), 
('Jessie', 'Agent', 'Poison Badge', 'F'),
('James', 'Agent', 'Poison Badge', 'M');

INSERT INTO Move (Move_name, Description, Types, overallStat)
VALUES
('Thunderbolt', 'Electric Move', 'Electric', 175),
('Hydro Pump', 'Water Move', 'Water', 135),
('Rock Throw', 'Rock Move', 'Rock', 100),
('Flame Thrower', 'Fire Move', 'Fire', 95),
('Poison Sting', 'Poisoning Move', 'Poison', 100),
('Neutralizing Gas', 'Poisoning Move', 'Poison', 65);

INSERT INTO Region (RegionName, Number_of_pokemons, Region_type)
VALUES
('Kanto', 155, 'Fire'),
('Johto', 107, 'Water'),
('Hoenn', 135, 'Earth'),
('Sinnoh', 120, 'Air'),
('Unova', 100, 'Earth');

INSERT INTO Item (ItemName, Effect, Type_of_item, RegionId)
VALUES
('Potion', 'Heals 20 HP', 'Restore Item', 1),
('Berry', 'Confuses Pokémon', 'Battle Item', 2),
('Great Ball', 'Catches Pokémon', 'Pokémon Catcher', 3),
('Rare Candy', 'Levels up Pokémon', 'Boost Item', 4),
('Escape Rope', 'Exits caves', 'Daily Item', 5),
('Soda Pop', 'Reduces Stress', 'Daily Item', 5);

INSERT INTO Pokemon (Pokemon_name, RegionId, Health, Speed, Attack, Abilities, Height_weight, Level)
VALUES
('Pikachu', 3, 35, 90, 55, 'Static', 0.07, 5),
('Staryu', 2, 30, 85, 45, 'Natural Cure' , 0.01, 10),
('Onix', 5, 35, 70, 45, 'Sturdy', 0.04, 8),
('Charmender', 1, 39, 65, 52, 'Blaze', 0.07, 7),
('Ekans', 1, 35, 55, 60, 'Intimidate', 0.30, 6),
('Koffing', 4, 40, 35, 65, 'Levitate', 0.60, 15);

INSERT INTO Evolution ( PokemonId, Evolved_form, Evolution_condition)
VALUES
(1, 'Raichu', 'Level up to 15'),
(2, 'Starmie', 'Level up to 15'),
(3, 'Steelix', 'Level up to 15'),
(4, 'Charmeleon', 'Level up to 15'),
(5, 'Arbok', 'Level up to 15'),
(6, 'Weezing', 'Level up to 15');

INSERT INTO Carries (TrainerId, ItemId)
VALUES
(1,1), -- Ash carries Potion
(6,3), -- James carries Great Ball
(4,4), -- Cynthia carries Rare Candy
(3,5), -- Brock carries Escape Rope
(2,6), -- Misty carries Soda Pop
(5,2); -- Jessie carries Berry


INSERT INTO USES (TrainerId, MoveId, PokemonId)
VALUES
(1,3,2), -- Ash uses Thunderbolt with Pikachu
(2,1,5), -- Misty uses Hydro Pump with Staryu
(4,6,5), -- Brock uses Rock Throw with Steelix
(4,3,1), -- Cynthia uses Flame Thrower with Charmeleon
(5,2,3), -- Jessie uses Poison Sting with Arbok
(6,4,4); -- James uses Neutralizing Gas with Weezing




3-	Open CmpeFF.sln file in CmpeFF folder with Visual Studio “Open a project or solution” option. 

4-	Change your connection string in the appsettings.json file with respect to your database’s connection string. You can access your connection string with the steps given below:
I-	Click view on the top navigation bar, click server explorer.
II-	Right click on Data Connection and click add a new connection and select the Pokemon database in your server.
III-	Click properties on your Pokémon database.
IV-	You can see your connection string in the properties window.

5-	After completing all these steps, click run https button in Visual Studio. You have all the CRUD permissions in the admin page.

6-	Note: Make sure you have Radzen installed in your NuGet packet manager.

7-  Do not update model from database as we fixed  recursion depth errors by some modifications to .cs files. When you update the model from databse, our modifications are reseted.

Technical Difficulties and Choices of the Project: 
When creating CRUD components for tables, Visual Studio didn't recongize our primary keys. So, we changed our primary keys names to ID. In this process we also realized that if we made our primary keys auto incremented, it is more practical.
Our initial decision was to create triggers in MSSQL Server Management Studio that changed our derived attribute,number of Number_of_pokemons in a region when a new pokemon is created or an exiting pokemon is deleted. Howeever, we decided to implement a code for it in C# instead.
We faced recursion depth errors. With necessary modifications to Cs files we fixed these errors.
Main difficulty was that we have no educational background on this project except database part. 
