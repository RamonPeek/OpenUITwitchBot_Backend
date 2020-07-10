using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock.Memory
{
    public class UserMemory
    {

        public static List<User> Memory { get; }

        static UserMemory()
        {
            List<User> data = new List<User>();
            data.Add(new User("shddgsagd", new TwitchAccount() { 
                Id = "1234567890",
                DisplayName = "MockChannel1",
                Description = "MockChannelDescription1",
                ViewCount = 4387438,
                ProfileImageUrl = "https://image.freepik.com/free-vector/machine-warrior-e-sports-logo-design-machine-warrior-gaming-mascot-twitch-profile_74154-43.jpg"
            }));
            data.Add(new User("sdasgfdsg", new TwitchAccount()
            {
                Id = "23671537625",
                DisplayName = "MockChannel2",
                Description = "MockChannelDescription2",
                ViewCount = 12323,
                ProfileImageUrl = "https://fiverr-res.cloudinary.com/images/q_auto,f_auto/gigs/123974106/original/9a8ac3c279b830e1a774bdbcf15b7a89ba493117/make-you-a-professional-gaming-banner-and-profile-picture.jpg"
            }));;
            data.Add(new User("bvcbvcbbc", new TwitchAccount()
            {
                Id = "33673663",
                DisplayName = "MockChannel3",
                Description = "MockChannelDescription3",
                ViewCount = 7767656,
                ProfileImageUrl = "https://fiverr-res.cloudinary.com/images/q_auto,f_auto/gigs2/114486158/original/ef1ebd076e28c081a69c83cee374fb56f29d27e5/make-you-a-custom-gaming-profile-picture.png"
            }));
            data.Add(new User("gsfsfdsff", new TwitchAccount()
            {
                Id = "12121212",
                DisplayName = "MockChannel4",
                Description = "MockChannelDescription4",
                ViewCount = 21212121,
                ProfileImageUrl = "https://static-cdn.jtvnw.net/jtv_user_pictures/vicioussyndicategaming-profile_image-f18df2e629df93c2-300x300.png"
            }));
            Memory = data;
        }

    }
}
