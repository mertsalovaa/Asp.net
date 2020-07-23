using EscapeQuest_DZ.Models;
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
            new Gallery{Image="https://images.squaremeal.co.uk/cloud/article/8990/images/12950f4a-c1ba-488c-87f7-a636fbccadbc.jpg?w=1000", RoomName="Sherlock"},
            new Gallery{Image="https://live.staticflickr.com/8600/16195340860_392f612600_b.jpg", RoomName="Sherlock"},
            new Gallery{Image="https://i.guim.co.uk/img/media/999f8fb856ab2d5953c304ddab6f248a4a6f75d7/0_174_5472_3283/master/5472.jpg?width=700&quality=85&auto=format&fit=max&s=dd37b95f94ea1c904c5cbbb492bf1a83", RoomName="Sherlock"},
            new Gallery{Image="https://escapequest.com.ua/Upload/49ab287f-1ac1-41b4-a8e1-57593bdb9ce7.jpg", RoomName="Spy Games"},
            new Gallery{Image="https://escapequest.com.ua/Upload/e3aba0a9-437e-435c-93a9-5a15523650d4.jpg", RoomName="Spy Games"},
            new Gallery{Image="https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/10/03/09/Crystal-Maze.jpg?w968", RoomName="Spy Games"},
            new Gallery{Image="https://images.buyagift.co.uk/common/client/Images/Product/Extralarge/en-GB/11885736_(1).jpg", RoomName="Spy Games"},
            new Gallery{Image="https://escapequest.com.ua/Upload/69112011-dfb2-4381-9763-1875a59156c6.jpg", RoomName="Da Vinci Code"},
            new Gallery{Image="https://escapequest.com.ua/Upload/8cfd6061-8571-43f0-80f1-5c3f6d531282.jpg", RoomName="Da Vinci Code"},
            new Gallery{Image="https://escapequest.com.ua/Upload/fd235f35-2705-4db0-b3cb-70444f8bda8b.jpg", RoomName="Da Vinci Code"},
            new Gallery{Image="https://escapequest.com.ua/Upload/7a1f5d94-0518-458f-b301-b7b06e7fff68.jpg", RoomName="Virtual reality"},
            new Gallery{Image="https://escapequest.com.ua/Upload/4b923724-ba6c-401e-8575-62876ace3c5f.jpg", RoomName="Virtual reality"},
            new Gallery{Image="https://i.ytimg.com/vi/B3ude0AUP3I/maxresdefault.jpg", RoomName="Virtual reality"},
            new Gallery{Image="https://i.ytimg.com/vi/3eBVc2zuQ8Y/maxresdefault.jpg", RoomName="Virtual reality"},
            new Gallery{Image="https://arkadymac.com/wp-content/uploads/2018/10/The-Garage-VR-Zone-Opening_0001.jpg", RoomName="Virtual reality"},
            new Gallery{Image="https://escapequest.com.ua/Upload/72cd5ac0-69e9-4aa1-bab0-18d1209ebf1c.jpg", RoomName="Star Wars"},
            new Gallery{Image="https://escapequest.com.ua/Upload/4f514b61-5957-4347-9935-39347ed9f50c.jpg", RoomName="Star Wars"},
            new Gallery{Image="https://escapequest.com.ua/Upload/94bd5e75-32e9-42c9-961d-c7a79c391239.jpg", RoomName="Star Wars"}
            };

            var address = new List<Address>()
            {
                new Address{ City="Lviv", Street="69 Dzherelna Str.", Lat="49.85", Lng="24.01"},
                new Address{ City="Lviv", Street="1 Rymlyanyna Str.", Lat="49.83", Lng="24.03"},
                new Address{ City="Lviv", Street="6 Konyskogo Str., (button on the intercom 7)", Lat="49.83", Lng="24.03"},
                new Address{ City="Lviv", Street="7v Stavova str", Lat="49.85", Lng="24.02"}
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
                    Address=address.FirstOrDefault(a=>a.Street == "69 Dzherelna Str."),
                    Galleries=gallery.FindAll(g=>g.RoomName == "Sherlock")
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
                    Address=address.FirstOrDefault(a=>a.Street == "1 Rymlyanyna Str."),
                    Galleries=gallery.FindAll(g=>g.RoomName == "Spy Games")
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
                    Address=address.FirstOrDefault(a=>a.Street == "1 Rymlyanyna Str."),
                    Galleries=gallery.FindAll(g=>g.RoomName == "Star Wars")
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
                    Address=address.FirstOrDefault(a=>a.Street == "7v Stavova str"),
                    Galleries=gallery.FindAll(g=>g.RoomName =="Virtual reality")
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
                    Address=address.FirstOrDefault(a=>a.Street == "69 Dzherelna Str."),
                    Galleries=gallery.FindAll(g=>g.RoomName =="Da Vinci Code")
                    }
            };


            context.Addresses.AddRange(address);
            context.Galleries.AddRange(gallery);
            context.EscapeQuests.AddRange(escapeRoom);

            base.Seed(context);
        }

    }
}