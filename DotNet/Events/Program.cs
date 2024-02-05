using Demo_2___EventsWithCustomArgs_MailService = Events.Demo_2___EventsWithCustomArgs.MailService;
using Demo_2___EventsWithCustomArgs_TextMessageService = Events.Demo_2___EventsWithCustomArgs.TextMessageService;
using Demo_2___EventsWithCustomArgs_Video = Events.Demo_2___EventsWithCustomArgs.Video;
using Demo_2___EventsWithCustomArgs_VideoEncoder = Events.Demo_2___EventsWithCustomArgs.VideoEncoder;
using Demo_3___EventsWithDotNetExistingDelegate_MailService = Events.Demo_3___EventsWithDotNetExistingDelegate.MailService;
using Demo_3___EventsWithDotNetExistingDelegate_TextMessageService = Events.Demo_3___EventsWithDotNetExistingDelegate.TextMessageService;
using Demo_3___EventsWithDotNetExistingDelegate_Video = Events.Demo_3___EventsWithDotNetExistingDelegate.Video;
using Demo_3___EventsWithDotNetExistingDelegate_VideoEncoder = Events.Demo_3___EventsWithDotNetExistingDelegate.VideoEncoder;
using MailService = Events.Demo_1___BasicEvents.MailService;
using TextMessageService = Events.Demo_1___BasicEvents.TextMessageService;
using Video = Events.Demo_1___BasicEvents.Video;
using VideoEncoder = Events.Demo_1___BasicEvents.VideoEncoder;

// 1 - Demo: BasicEvents
Console.WriteLine("Executing Demo 1");

var video = new Video() { Title = "Video 1" };

var videoEncoder = new VideoEncoder(); // Publisher
var mailService = new MailService(); // Subscriber
var messageService = new TextMessageService(); // Subscriber 

// Subscribing
videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

videoEncoder.Encode(video);

// 2 - Demo: EventsWithCustomArgs
Console.WriteLine("Executing Demo 2");

var video2 = new Demo_2___EventsWithCustomArgs_Video() { Title = "Video 2" };

// Subscribing
var videoEncoder2 = new Demo_2___EventsWithCustomArgs_VideoEncoder(); // Publisher
var mailService2 = new Demo_2___EventsWithCustomArgs_MailService(); // Subscriber
var messageService2 = new Demo_2___EventsWithCustomArgs_TextMessageService(); // Subscriber 

videoEncoder2.VideoEncoded += mailService2.OnVideoEncoded;
videoEncoder2.VideoEncoded += messageService2.OnVideoEncoded;

videoEncoder2.Encode(video2);

// 3 - Demo: EventsWithDotNetExistingDelegate
Console.WriteLine("Executing Demo 3");

var video3 = new Demo_3___EventsWithDotNetExistingDelegate_Video() { Title = "Video 3" };

// Subscribing
var videoEncoder3 = new Demo_3___EventsWithDotNetExistingDelegate_VideoEncoder(); // Publisher
var mailService3 = new Demo_3___EventsWithDotNetExistingDelegate_MailService(); // Subscriber
var messageService3 = new Demo_3___EventsWithDotNetExistingDelegate_TextMessageService(); // Subscriber 

videoEncoder3.VideoEncoded += mailService3.OnVideoEncoded;
videoEncoder3.VideoEncoded += messageService3.OnVideoEncoded;

videoEncoder3.Encode(video3);
