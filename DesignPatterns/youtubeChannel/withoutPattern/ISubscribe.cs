using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.withoutPattern
{
	interface ISubscribe
	{
        void subscribe(YouTubeChannel toSubscribe);
        void unsubscribe(YouTubeChannel toUnsubscribe);
	}
}
