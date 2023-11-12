using BasicEvents = Events.BasicEvents;
using EventsWithCustomArgs = Events.EventsWithCustomArgs;
using EventsWithDotNetExistingDelegate = Events.EventsWithDotNetExistingDelegate;

// 1 - Demo: BasicEvents
Console.WriteLine("Executing Demo 1");

var video = new BasicEvents.Video() { Title = "Video 1" };

var videoEncoder = new BasicEvents.VideoEncoder(); // Publisher
var mailService = new BasicEvents.MailService(); // Subscriber
var messageService = new BasicEvents.TextMessageService(); // Subscriber 

// Subscribing
videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

videoEncoder.Encode(video);

// 2 - Demo: EventsWithCustomArgs
Console.WriteLine("Executing Demo 2");

var video2 = new EventsWithCustomArgs.Video() { Title = "Video 2" };

// Subscribing
var videoEncoder2 = new EventsWithCustomArgs.VideoEncoder(); // Publisher
var mailService2 = new EventsWithCustomArgs.MailService(); // Subscriber
var messageService2 = new EventsWithCustomArgs.TextMessageService(); // Subscriber 

videoEncoder2.VideoEncoded += mailService2.OnVideoEncoded;
videoEncoder2.VideoEncoded += messageService2.OnVideoEncoded;

videoEncoder2.Encode(video2);

// 3 - Demo: EventsWithDotNetExistingDelegate
Console.WriteLine("Executing Demo 3");

var video3 = new EventsWithDotNetExistingDelegate.Video() { Title = "Video 3" };

// Subscribing
var videoEncoder3 = new EventsWithDotNetExistingDelegate.VideoEncoder(); // Publisher
var mailService3 = new EventsWithDotNetExistingDelegate.MailService(); // Subscriber
var messageService3 = new EventsWithDotNetExistingDelegate.TextMessageService(); // Subscriber 

videoEncoder3.VideoEncoded += mailService3.OnVideoEncoded;
videoEncoder3.VideoEncoded += messageService3.OnVideoEncoded;

videoEncoder3.Encode(video3);
