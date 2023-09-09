using Observer;

Console.Title = "Observer";

var ticketStockService = new TicketStockService();
var ticketResellerService = new TicketResellerService();
var orderService = new OrderService();

orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);

orderService.CompleteTicketSale(1,1);

orderService.RemoveObserver(ticketResellerService);

orderService.CompleteTicketSale(2,2);