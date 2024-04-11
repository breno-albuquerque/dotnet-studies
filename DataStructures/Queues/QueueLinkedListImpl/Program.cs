using QueueLinkedImpl;

var queue = new LinkedQueue();

queue.Enqueue(10);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Enqueue(20);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Enqueue(30);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Enqueue(40);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Enqueue(50);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Enqueue(60);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Enqueue(70);
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());

queue.Dequeue();
queue.Display();
Console.WriteLine("Front: " + queue.GetFront());