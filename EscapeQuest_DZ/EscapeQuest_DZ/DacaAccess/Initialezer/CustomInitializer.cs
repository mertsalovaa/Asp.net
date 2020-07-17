﻿using EscapeQuest_DZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EscapeQuest_DZ.DacaAccess.Initialezer
{
    public class CustomInitializer : DropCreateDatabaseAlways<EscapeContext>
    {

        protected override void Seed(EscapeContext context)
        {
            var gallery = new List<Gallery>()
            {
            new Gallery{Image="https://escapequest.com.ua/Upload/acd224ee-2db9-404a-a322-2ad7e0f24aac.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/8ead4507-a19f-4d32-a7ba-10296e666e53.jpg"},
            new Gallery{Image="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQZB7SidRlAJ7Nfh3_-OacrcjHi7hyZXH9l0w&usqp=CAU"},
            new Gallery{Image="https://escapequest.com.ua/Upload/49ab287f-1ac1-41b4-a8e1-57593bdb9ce7.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/e3aba0a9-437e-435c-93a9-5a15523650d4.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/4bec6f32-c6bd-4b06-8d0c-fa5b35f7ae24.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/69112011-dfb2-4381-9763-1875a59156c6.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/8cfd6061-8571-43f0-80f1-5c3f6d531282.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/fd235f35-2705-4db0-b3cb-70444f8bda8b.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/7a1f5d94-0518-458f-b301-b7b06e7fff68.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/4b923724-ba6c-401e-8575-62876ace3c5f.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/72cd5ac0-69e9-4aa1-bab0-18d1209ebf1c.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/4f514b61-5957-4347-9935-39347ed9f50c.jpg"},
            new Gallery{Image="https://escapequest.com.ua/Upload/94bd5e75-32e9-42c9-961d-c7a79c391239.jpg"}
            };

            var address = new List<Address>()
            {
                new Address{ Country="Ukraine", City="Lviv", Street="69 Dzherelna Str."},
                new Address{ Country="Ukraine", City="Lviv", Street="1 Rymlyanyna Str."},
                new Address{ Country="Ukraine", City="Lviv", Street="street Koniskoho, 6 (on the intercom 7)"},
                new Address{ Country="Ukraine", City="Lviv", Street="7v Stavova str"}
            };

            var escapeRoom = new List<EscapeQuest>()
            {
                new EscapeQuest{ Name="Sherlock",
                    Desc="Sherlock, last time you solved my genius riddle and saved London from an explosion. But the game is not over yet ... I challenge you again and this time it will be the other way around! Your Moriarty.",
                    MinAge=8,
                    CountPlayer="2-4",
                    Phone="0982776680",
                    LevelDifficulty=3,
                    LevelFear=3,
                    Price=600,
                    Rating=5,
                    Email="lviv@escapequest.com.ua",
                    Address=address.FirstOrDefault(a=>a.Street == "69 Dzherelna Str.")
                    },

                new EscapeQuest{ Name="Spy Games",
                    Desc="Your team has come a long way in the Secret Spy Academy, and now you need to make the final exam. Show yourself as a united team of professionals. Details of the task you'll get before the exam, which will last only an hour.",
                    MinAge=8,
                    CountPlayer="2-5",
                    Phone="0689900558",
                    LevelDifficulty=4,
                    LevelFear=4,
                    Price=550,
                    Email="hub@escapequest.com.ua",
                    Rating=4,
                    Address=address.FirstOrDefault(a=>a.Street == "1 Rymlyanyna Str.")
                    },

                new EscapeQuest{ Name="Star Wars",
                    Desc="Earth is in danger - the super-powerful laser beams of the Death Star are already aimed at every continent. Your team managed to get on it to find and defuse the forces of Darth Vader. You must prevent the attack of the Dark Forces on our planet and save billions of lives, and for this mission you have only 60 minutes, because then there will be no where to go back! May the Force be with you.",
                    MinAge=8,
                    CountPlayer="2-5",
                    Phone="0689900558",
                    LevelDifficulty=4,
                    LevelFear=4,
                    Price=550,
                    Rating=4,
                    Email="hub@escapequest.com.ua",
                    Address=address.FirstOrDefault(a=>a.Street == "1 Rymlyanyna Str.")
                    },

                 new EscapeQuest{ Name="Virtual reality",
                 Desc="Book a time, come to the club and choose a game or a escape room.",
                    MinAge=8,
                    CountPlayer="1-4",
                    Phone="0506112943",
                    LevelDifficulty=3,
                    LevelFear=3,
                    Price=250,
                    Rating=5,
                    Email="legendary@escapequest.com.ua",
                    Address=address.FirstOrDefault(a=>a.Street == "7v Stavova str")
                    },
                 new EscapeQuest{ Name="Da Vinci Code",
                 Desc="The secret code is hidden in the works of Leonardo da Vinci... Will you find the key to the greatest mystery of the humanity?",
                    MinAge=8,
                    CountPlayer="2-4",
                    Phone="0982776680",
                    LevelDifficulty=4,
                    LevelFear=4,
                    Price=600,
                    Rating=5,
                    Email="lviv@escapequest.com.ua",
                    Address=address.FirstOrDefault(a=>a.Street == "69 Dzherelna Str.")
                    }
            };


            context.Addresses.AddRange(address);
            context.Galleries.AddRange(gallery);
            context.EscapeQuests.AddRange(escapeRoom);

            base.Seed(context);
        }

    }
}