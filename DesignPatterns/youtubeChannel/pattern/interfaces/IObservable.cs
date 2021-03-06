﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.youtubeChannel.observerPattern.model;

namespace DesignPatterns.youtubeChannel.observerPattern.interfaces
{
    interface IObservable
    {
        void registerObserver(IObserver observer);
        void removeObserver(IObserver observer);
        void notifyObservers(Notification notification);
    }
}
