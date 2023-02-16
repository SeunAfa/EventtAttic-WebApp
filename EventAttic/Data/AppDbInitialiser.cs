using EventAttic.Data.Enums;
using EventAttic.Data.Static;
using EventAttic.Models;
using Microsoft.AspNetCore.Identity;

namespace EventAttic.Data;

public class AppDbInitialiser
{
    //default data 
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            //Event Location 
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(new List<EventLocation>()
                {
                    new EventLocation()
                    {
                       Venue = "Cargo",
                       StreetAddress = "The Printworks",
                       City =   "Manchester",
                       PostCode = "M4 2BS"
                    },
                    new EventLocation()
                    {
                       Venue = "Ministry of Sound",
                       StreetAddress = "103 Gaunt St",
                       City =   "London",
                       PostCode = "SE1 6DP"
                    },
                    new EventLocation()
                    {
                       Venue = "LEVEL Nightclub",
                       StreetAddress = "18-20 Fleet St",
                       City =   "Liverpool",
                       PostCode = "L1 4AN"
                    },
                    new EventLocation()
                    {
                       Venue = "Manchester Academy",
                       StreetAddress = "Oxford Rd",
                       City =   "Manchester",
                       PostCode = "M13 9PR"
                    },
                });
                context.SaveChanges();
            }

            //Artist
            if (!context.Artists.Any())
            {
                context.Artists.AddRange(new List<Artist>()
                {
                  new Artist()
                    {
                       ArtistName = "Meek Mill",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                       ProfilePictureURL = "https://media.pitchfork.com/photos/5d435ce093a6c90008014e75/4:3/w_1516,h_1137,c_limit/GettyImages-1157882425.jpg",
                       StagePictureURL = "https://www.rollingstone.com/wp-content/uploads/2021/10/meek-mill-review.jpg",
                       SpotifyPlayList = "https://open.spotify.com/artist/20sxb77xiYeusSH8cVdatc?si=r8KsFUG-SH6ftTdROPfedQ",
                       InstaLink = "https://www.instagram.com/meekmill/?hl=en",
                       TwitterLink = "https://twitter.com/MeekMill?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor"
                    },
                  new Artist()
                    {
                       ArtistName = "Billie Eilish",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                       ProfilePictureURL = "https://www.hdwallpapers.in/download/white_hair_billie_eilish_is_wearing_blue_jean_dress_standing_in_sage_green_background_hd_billie_eilish-HD.jpg",
                       StagePictureURL = "https://www.nme.com/wp-content/uploads/2022/02/Billie-Eilish-world-tour.jpg",
                       SpotifyPlayList = "https://open.spotify.com/artist/6qqNVTkY8uBg9cP3Jd7DAH?si=7hiGEAKARXa2zoX_zWWzbw",
                       InstaLink = "https://www.instagram.com/billieeilish/?hl=en",
                       TwitterLink = "https://twitter.com/billieeilish"
                    },
                  new Artist()
                    {
                       ArtistName = "Marshmello",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                       ProfilePictureURL = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBEREhgPEREPERIPERERDxERDxEPDxARGBgZGRgYGBgcIS4lHB4rHxgYJjgmKy8xNTU1GiU7QDszPy40NTEBDAwMEA8PGBERGDQhGCExMTQ0MTQxNDQ0NDQxNDQ0NDQxNDQ0NDExMTE0NjExMTE0NDE0PzRAND8xMT8/MT8xNP/AABEIAOEA4QMBIgACEQEDEQH/xAAcAAACAgMBAQAAAAAAAAAAAAACAwQFAAEGBwj/xABHEAACAQMBAwkEBQkFCQEAAAABAgADBBEhBRIxBhMiQVFhcYGRBzKhwRRCUnKxI2KCkqKy0eHwMzR0g7MkNURTc5TC0vEV/8QAFwEBAQEBAAAAAAAAAAAAAAAAAAECA//EABwRAQEAAgIDAAAAAAAAAAAAAAABETEhQQISUf/aAAwDAQACEQMRAD8AukSSFWCiyQiyNsRY5RNKIxRCMURiiaAjFEqMAhATAIYEI0BNgQgIQEAQJvEICbxAHEzEPEzEAMTWIzE1iAsiaIjMQSICyIJEYRBIgLMExhEEiAowTGEQCIUphFuI5hFMJBHZZHdZLcRLrJVRd2ZG7syRUtFjkEFVjlE0jaiMUTSiMUQjYENRMUQ1EowLCAmwIYEI0BNgTYEICAIE3iGBN4gBiZiHiZiAGJrEZiZiUKxNFY0iCRAUVglY4iCRIElYBWPKwCsBJWLKx7LAZYEdhAYR7LAZYVGZYl1kplinWRUbdmo7EyBJURiiaURiiVBKI1RBUQ1EAlEYBBAjAIRgEICaEMQMAhAQcjhGqmYAgQlQngDJCIB1fOOQyplFFBuvSFzPfJdXtiTAQyASJXYrqOqTmkS4XSRYLEwiaonKjwx6aQ5QsiCRGEQTAWRNEQyIJgLIi2EcRAYSBDCLYRzCAwgIYRTCPYRbCFJ3ZkPEyRTlEYsBYxZUMWGsBYawhghCCIQgEIQgiFKIatiowz15HnLGm051Pyd1VTqcpWXwcbpA/SQ+szlDyopbOSnUrJWdKrlC1NVbcwM5IJHbJKtjqVMYrTzflf7Q6FOzD7PuKVSvcncpkYZ6C4yzuh1VuAAYcTnXEV7HNr3d0lz9Jr1a6I9Hm2quXKswcuAx1xgLpwHVxlZeg7d25bWNH6Rc1BTp7wRTgsWc5IUKASTgE+AMr9i8q7C/JS1uEqOMk0yGpVcDiQrAFh3jIg8s+Tq7Ss2tiwR1YVLdzndSqoIG9j6pDMD456p84XtpVtqrUaoalVosUdSSGUjsI4gjgRoQe+B7Fde0je2nTsrZKb230hLerVbeZqru4QmmQcBVLZyc72D3Tv6k+auSt3SoXtCvXJWlRrJUcqpYjd1BwOOGAn0bZX1K5prXoOlWm4yrocg9o7iOsHUSA7Y6Edh/GPMjUThyO0fhJMKEwTDMEygDBMMwDAAwTDMEyBTRbCNaLaApopo1otoUuZNzJA1YxYpYxZQ1YYgLDEIMQhBEIQDE3ABhAyin20u5VpVft85RbzG+vxQj9KRuUux0v7N7diqvjfou2irUUHBJ6gQSpPYxljt6mWt3KjLUt2sg6yyEPjzwR5yi5UXDDZty1M6m3bBB+o2Ax/VJme6t08FP/wAno3sy5aWuz6bW1ylReer85z6AMqAqq4dfeAG6TkZ97hPOuI8JoSsvqXbO0/o9pVu0CvzNu9ZBnKPhCy6jqOnlPmfal/Vuaz3FZy9Sq287EAZOABgDQAAAAdQAnt3IH/btiLb1GJ3qdzaM3WE6Sr6Ky+k8OvbWpQqNQrKUqUmKOraMrD5deesGWiOJ6H7HdqVEuns94mncU3cLqd2qmDvDsyu8D24HZFcmfZrVvbM3TVjbu5P0dHpEq6D67nOQGPDA4DOuZ1HIT2fV7C5+l3NSizIjJSSizMMvoWYso6s6Y6+6RXeMcMD349dJKlOm1LetUq0KVVHqWrBa6LnKMeAzwPAjTOCMcZao2QD2gGARgmZNGUaMEzZgmAJgmETAMgBoDQmMBoC2i2htFtChmQczJA5YxYtYayhqwlgCEsIaIQMWDCEAxCEETYlG2AIweBGD4Tm7K3V6L2lQZXFW1cde7qg89wqfOdLOb2qtSnUrcyQKlShz9LIBBqIpVsjr91PWZu4s1Xn2x/ZndG83LgKLRCS9ZKig1lHBUXJYE6A5AwM9eM3+0vZHRerv21y1vTOPyT0jcFD17r74JHcde/smcnvaNa1MU7s/Rao03iCbd+8NxXwb1M6heVOzuP0+x/7qj/7TTKZye2NSsLdLWiWKJvEs5Bd2YksxxpxP4SbVs6TsHelSd1913pozqO5iMic3e+0DZVH3rtHP2aKvWJ81BHqZzO0vbBQXS1tatQ5I3qzLRXx3V3ifDSB6cZwPL7l5Ts0a2tXWpdsCpZcMttnTeY8C/Yvmew+b7d9oO0bsFDWFCm2hp2wNIEdhbJY+Gcd0h8leSd1tFwKSlKSnFS4dTzSDrx9pvzR54Gsg6r2P29R69xcHeKClzbs2TvVXdX4nicIxP3h2z1y2bojuyJC2PsajZW6W1BSEQHLNqzufedj1sf4AaASTbOAWTIzkHGddc/whUmCZswTKNGAYRgmBowDCMAyAGgNDaLaAtopjGMYpjChzMmpkgesNYtTDEoYDDBiwYYhDBCEAQhAYIQgAwhKDEq9tpumnWGhR+bY/mvoP2wksxEbQoc5TZOBcYU4zuvxU+RxJdLNvNuU/s8NwxuLJ0R2JZ7eod2mWPHcb6v3Tp3jhOIq8i9qIcGxuTj7CCovqpIntH/69OiStQVEIJ+oWyAeIx1RVflxZ013t25fuWjgn9YiSWFleQUOQu1qnu2NYffKUh+2wnQ7O9kl85Br1re3U8cFq9QeQwv7U6ut7S6eCaNpVbHE1KiUwPJd6RqXKzad30bei1JW4VKVs1Yj9N8r8IzExVnsb2YbOt8PW37p11zWISiCPzF0I7mJl7c7fsbamVWpT3aQ3QlAK4TH1QF6K+Gk5Yciry7O/fXd1VQ8aT1AlM+KocD0lzb8h7YbvOlnRNEooOaoKPAdInvzLz1Dj6TYcori/Y/RqRpUkcKz1OlUYHGumi/GdJbWm4uN4sz6sTr6STQtKdNdymiooGioAq8OwRr6HTjjAkxzlc8YRVBwc64OMzRkwpgYkeqmunjNISTBJmzAJkGiYBM2TAJgaYxbGGximMAWMSxjGimMK1Mg5mpBJBhrEqYxTKhohiKBhgwGiEIAM2DAaIYigYYMoYsfRTIORxiEGfl48ZJt31I7if69ZAl7am/QqKjlRoGCswHAHu4SI+wLR9GoIcaYwcYPnIe0rJ/phvaO9zlC1pB6Y925ol6pZCPtDdyp7RjgTL+g6uu+pBV1VlI4EEaGVFVa7CtKWtO2oIwOrLTXe9eMs04QnGDnqOh8YSrAHGISjX8Zjaa+kJFx84G2lfa7Tp1bmrbLvGparSNXIG4OdBZMHtwufSSNp3qW9J69Rt1KSM7N2KoyfEzluRdnURvptdStbaorXFVTnKKChtqf6NMv3690DsSNMHqka5OAD1gjzkljkZka4OSP64sP5wqPXXB7jqIkmSbsaA+P8pEJkGiYJM2TAJgaYxTGETAYwAYxbGExi3MK1mZAzMkDlMapiFMNTKiQDCBiVMYDAaDDBiQYYMBoMIGLBhrAl2w1I7h/Xwh0wcgjtI/r0xF25/KEfmL+LRvBivbhh85Qqif8AaX/w9v8AB68Rybrb1JkIwaFe4obv2USowT9jcPnJXNDnOcyclAhGNCAxIOfM+sgWCCne10AwtenRufGp0qTn9VKUIuKi5GPTxmqbZGYwxCdY7CYBE5MYDE0+2VHKzbBs7SpXXBdVC0weBqOd1M92SCe4GBV7dc7Sul2ag3ra2dK+03+od3pU7fvLEKzDqAnVVlyVIwCjZB3QSOo4zwyNPOeKWvLG/pUxSotRpDLMzJQRnd21Z3L7285OSTFVeWe1Dr9LbwFKgv4JGWfZ7kXiwcnPZ/P+PwnhNXlZtFlOb2v+juIfgs9c5G3hr2dGozOzbmHZ23nLhiup6+GYysq4ux0PPMryZY3fuHuA/ESrJkaYTAJmyYBMDTGAxm2MUxgaYxTmEzRLGFZmbgZmSBymMBkdGjAYQ9TDBiVMNTKHKYYMSDDUwHAxtLU4kcGOt26XkflAk2x/KEZ1CqO/GSR+MlV14N2cfA8flIpGKin7SsPHGCPnJ3EYPAiUADpKG+rmntO2Y6Jc211bg9XOhkqKD3lVfHgZeU+GOwY8xK/buzzcUSqYFWkVr2rHPQrp0k8ieie0MYRcAxK9fjE7LvUuKSXCZ3ayLUUHQgMucHvHCNTrgYhnD+1VHe2XcI3KLpVr6nUMTTQd/SYn9GduTicry7TNncn7VtRI7ubqlif2xCV46XIOhAGDnI1J0wOOnX6CA1VQeIx4iKWow03Ce8YAPf3GJZF3guFyeHRHCZZMqVgwwpGe7We0ey5ydnqSdDWq7vcAQuPUH1nitPRBj7IPwn0Hyaskt7OjRVQm7SRnA+243nJ7yxMsai1rao33WlOTLdtQR2giUpMrTZMFjNEwCZBpjFsYTGJYwNM0U7TbGJdpBvM3F5mQpyNGK0io0crQJCtGqZGVoxWhDwYxTEK0NWlDwY62Yc4FPWrAj0/gZFDQgOkjg9JT0hnUqeuBZuNQD7yMCO9TpJi/hI7pvrkcV1EeJQOePiYSH8JGov7w695vx/lJC/KEUmwKbW1SrZN7i1HubRupqFRizJ4o7MPBk7ZdLxka/G7uVca06ig4482/QYHuyVb9CSc6wBqcZyvKe4522v0H/DWvN94c0zVJ9GT9WdVVnG7VTK7TRdS9pTdh+eaVRT+yiQlePI+Ne8knPYIqi4ZmfjgRtJGcdBGfPAIrOTnuAk+nybvSj1Vta60wjFmdRRCqAcnDkHEyyq7am1VlQZ+ooA+s5xgfET6XUYGJ4vyZ5HXvO21V6G7RNShWZzVosOb3lfJUNnUDhjrns4DHgMDtMsagwZRMZdMcacZR1T0j4n8Za00TBYzRaAzSDGaKZpjNFM0g07RTtNu0Q7QC3pkVvTIDUaOVpCR45XhUtWjVaRFeMVoRKVowNIytDDyiQGkjc3hnXojUA43hx9ZDVpKFZqbYddOp14eY6oFpZPpoc47eOO+SmYdkg2zjOmmeB6j5yXr3SoQigZPHJJ+MkqZDok65+1kef85LQwCqIHUowyrgqw7QRgyBsms9SjTd9Xamhc4xvNjVvPj5yZWLbjbvvBWK/exp8Yi23dxNz3ObTd+7ujHwgPqShtqJS/rEjoXNrbsp/PpO6OPR0+Mvmlfzq/SFT6xo1mHbuh6QP4iBOVcDSUvKWmptKqOSBVQ02I6t8hNP1sS7QznuWXSopS0HO3dmh7cCsj/+EC8poAVUAYB4dQAGnykmq+IlD0s9g08Sf5Roxx64EfmydSSB1gafzlHVfJJ7SSPWdBVecxUOCR2EiFbZoLNAZ4pnkBs0U7QWeJd5Bt3iXead4h3gM3pkj783AJHj0eVtOpJCPCrFHjFeQVeOV4RMV4wPIa1IwPAlh5cWFValNWbB3hhs/aGh+IlAtSSuT91jKNjQ5GOH9Yx5gyi+SjuHonKE6qdd3vEku2nEAdZ7BMplGGQFM1VpZGBgZlQtSOrhpjt11jaT59cSDbVw3DsyPCOtn1YdjZ9YExG1xK6xqY36f/IqNTHZulVdB5K6jyk12xr2SotbnN5XpAdHm7Wvn85+cQ/CisC2LaTnLioV2nbEnAq218g78Nbt8peNUxOZ2/VK32z6nBVe6onxqU94fuQOtBnN8rq5V7QBHfev6Bbd3TgAkZOSOth6TolModsPm8tU6s1X/SUoR8z5GB0CCE02owIqqxgJrVePcPOc7WfpH7x/GXznOneCfLWcs9TOvbrFDGeLZ4pnimqTKms8S7wHeIZ4Bu8S7wHeR3qQHb8yROcmQMp1JISrKhKskJVgWyVI9KkqkqSQlWBZrUhLUkBKkNakCwV4drmm61dOaqZR2zpTcMQrHuJyD3k9sgCpH7E2kgq1LSoRht2om9jdKuMFf1lPrA6+1tVPS3ySdcg4Hwjby65tSAxY4JGdd0YkO0pU6fRQYY/nZwJJqBNxtOKtknUnTtmhX7Nrfu4kuyr/AJQjtUeolDs6rgnyz8ZOs62Ko78j5SQq3uqzqQwAYZx3+B7pQV7rm9oBjkLXsununew1Kqd3h/1n9JfvroeBEqrasEvt1h0jaHcCjgqVen3/AF0lRJF+p+pUXvKOSfQSr2+gamlRUqF6d3aOrNTdVVTUVHOSNBuuwnTrdodctpxyjg/hI95eU+bbeJK7pz+TdgPhAYlQYydBx8uM5mvXNS9puASUZdwdz0roH4U8ydXusW+8D76qo8ziU2yq61bhSDhqV7zY11KLZ1zvY++7jyko7kN8NIm4YgRKXAzhm3H4a6BputUPaAfUH1lEStUxjOes6cJywqaDwEk8sOUC2tNaK617k82mNCiEgO57MA4Hee4ysLyVT2eKZ4lqkU1SQOd4p3iXqRD1IDHeR3qQHqRDvAdzkyROcmQNU5JSZMgSEjkm5kKekNZkyEMEotqf3tf8M3+okyZCx29t7qf5cuL73R4/KZMmukUFj1+PyMm2v9ov3hMmTMWr48R5yif/AHmn+Duv37abmTbK7PvH7q/OQdqf2Z+/Q/1EmpkIp0/udL/KlJya/vqf4i7/AHXmTJi7jp46rvtp/wBn5H8JydD+1Hj8pkyarMcRyj/3hT+5R/fadM0yZIFmLaZMkCWiXmTIEepEPNzIC5kyZA//2Q==",
                       StagePictureURL = "https://res.cloudinary.com/purnesh/image/upload/w_1000,f_auto/marshmello-final-image-1920-high.jpg",
                       SpotifyPlayList = "https://open.spotify.com/artist/64KEffDW9EtZ1y2vBYgq8T?si=wKVQ8Z0HTJCEo-g1uCW9Kg",
                       InstaLink = "https://www.instagram.com/marshmello/?hl=en",
                       TwitterLink = "https://twitter.com/marshmello"
                    },
                  new Artist()
                    {
                       ArtistName = "Jhené Aiko",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.    ",
                       ProfilePictureURL = "https://i.pinimg.com/originals/38/1a/bc/381abc76b140c6c86e874fc081c76ca0.jpg",
                       StagePictureURL = "https://live.staticflickr.com/65535/46910635035_a093c22596_b.jpg",
                       SpotifyPlayList = "https://open.spotify.com/artist/5ZS223C6JyBfXasXxrRqOk?si=ey5ccR-iRoCcxfFITGURaw",
                       InstaLink = "https://www.instagram.com/jheneaiko/?hl=en",
                       TwitterLink = "https://twitter.com/jheneaiko"
                    },

                });
                context.SaveChanges();
            }

            //Organiser
            if (!context.Organisers.Any())
            {
                context.Organisers.AddRange(new List<Organiser>()
                {
                    new Organiser()
                    {
                       EventOrganiserName = "LondonLux",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ",
                       ProfilePictureURL = "data:image/png;base64,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",
                       InstaLink = "https://www.instagram.com/luxguestlist/?hl=en",
                       TwitterLink = "https://twitter.com/luxguestlist?lang=en"
                    },
                    new Organiser()
                    {
                       EventOrganiserName = "Nightplans",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ",
                       ProfilePictureURL = "https://lirp.cdn-website.com/e69a0f7a/dms3rep/multi/opt/Nightplans+logo+black-14628ea5-462w.jpg",
                       InstaLink = "https://www.instagram.com/nightplans/?hl=en-gb",
                       TwitterLink = "https://twitter.com/night_plans"
                    },
                    new Organiser()
                    {
                       EventOrganiserName = "Privilege Entertainment",
                       Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ",
                       ProfilePictureURL = "https://pbs.twimg.com/profile_images/2939464461/d7ef12caf84b895069cb1ef5870c9903_400x400.jpeg",
                       InstaLink = "https://www.instagram.com/privilegeent/",
                       TwitterLink = "https://twitter.com/PrivilegeProm"
                    }

                });
                context.SaveChanges();
            }

            //Event
            if (!context.Events.Any())
            {
                context.Events.AddRange(new List<Event>()
                {
                    new Event()
                    {
                        Name =  "Quids In Monday",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                        Price= 1,
                        ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/03/d3/15/39/roo-night-club.jpg?w=1200&h=-1&s=1",
                        StartDate = DateTime.Now.AddDays(4),
                        EndDate = DateTime.Now.AddDays(12),
                        EventLocationId = 2,
                        OrganiserId =2,
                        EventGenereCategory= EventGenereCategory.House,
                        AgeRestriction ="18",
                        TimeTill ="10pm to 5am"
                    },
                    new Event()
                    {
                        Name =  "The Jungle Weekender",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                        Price= 13.50,
                        ImageUrl = "https://www.get-licensed.co.uk/get-daily/wp-content/uploads/2021/07/Packed-Club-Unsplash.jpg",
                        StartDate = DateTime.Now.AddDays(10),
                        EndDate = DateTime.Now.AddDays(26),
                        EventLocationId = 1,
                        OrganiserId =1,
                        EventGenereCategory= EventGenereCategory.HipHop,
                        AgeRestriction ="18",
                        TimeTill ="10pm to 4am"

                    },
                    new Event()
                    {
                        Name =  "UK Garage Boat Party",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                        Price= 24,
                        ImageUrl = "https://static.urbandaddy.com/uploads/assets/image/articles/standard/03e7f132efb8003ad372f513ceb3cfbf84c187e8.jpg",
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(29),
                        EventLocationId = 4,
                        OrganiserId =2,
                        EventGenereCategory= EventGenereCategory.UKGarage,
                        AgeRestriction ="18",
                         TimeTill ="10pm to 5am"
                    },
                    new Event()
                    {
                        Name =  "VIP Fridays",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                        Price= 15,
                        ImageUrl = "https://media.timeout.com/images/58938/750/562/image.jpg",
                        StartDate = DateTime.Now.AddDays(1),
                        EndDate = DateTime.Now.AddDays(22),
                        EventLocationId = 4,
                        OrganiserId =1,
                        EventGenereCategory= EventGenereCategory.Electronic,
                        AgeRestriction ="18",
                        TimeTill ="10pm to 5am"
                    },
                    new Event()
                    {
                        Name =  "New Year Big Bash",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                        Price= 25,
                        ImageUrl = "https://media.timeout.com/images/103654233/image.jpg",
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(12),
                        EventLocationId = 2,
                        OrganiserId =3,
                        EventGenereCategory= EventGenereCategory.House,
                        AgeRestriction ="18",
                        TimeTill ="10pm to 5am"
                    },
                    new Event()
                    {
                        Name =  "All Night Light",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                        Price= 25,
                        ImageUrl = "https://static.designmynight.com/uploads/2022/06/chinawhite-manchester-2-1-optimised.jpg",
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(15),
                        EventLocationId = 2,
                        OrganiserId =3,
                        EventGenereCategory= EventGenereCategory.House,
                        AgeRestriction ="18",
                        TimeTill ="10pm to 5am"
                    },

                });
                context.SaveChanges();
            }

            //Artist_Event
            if (!context.Events_Artists.Any())
            {
                context.Events_Artists.AddRange(new List<Event_Artist>()
                {
                new Event_Artist()
                {
                    ArtistId = 1,
                    EventId = 2,
                },
                new Event_Artist()
                {
                    ArtistId = 2,
                    EventId = 3,
                },
                new Event_Artist()
                {
                    ArtistId = 3,
                    EventId = 4,
                },
                new Event_Artist()
                {
                    ArtistId = 4,
                    EventId = 1,
                },
                });
                context.SaveChanges();
            }

        }
    }

    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            //Default User Rolese
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //Users - Admin
            var userManaager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "admin@EventtAttic.com";

            var adminUser = await userManaager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    FullName = "Admin User",
                    UserName = "admin",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                };
                await userManaager.CreateAsync(newAdminUser, "AdminNues1010@");
                await userManaager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            //Users - Customer
            string applicationUserEmail = "user@EventtAttic.com";

            var User = await userManaager.FindByEmailAsync(applicationUserEmail);
            if (User == null)
            {
                var newApplicationUser = new ApplicationUser()
                {
                    FullName = "Application User",
                    UserName = "User",
                    Email = applicationUserEmail,
                    EmailConfirmed = true,
                };
                await userManaager.CreateAsync(newApplicationUser, "AppUser1425!");
                await userManaager.AddToRoleAsync(newApplicationUser, UserRoles.User);
            }

        }
    }
}
