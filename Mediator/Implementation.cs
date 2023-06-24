namespace Mediator
{
    public interface IChatRoom
    {
        void Register(TeamMember teamMember);
        void Send(string from, string message);
    }

    public abstract class TeamMember
    {
        private IChatRoom? _chatRoom;
        public string Name { get; set; }

        public TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatroom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void Send(string message)
        {
            _chatRoom?.Send(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"Message {from}, to {Name}: {message}");
        }
    }

    public class Lawyer : TeamMember
    {
        public Lawyer(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> _teamMembers = new();

        public void Register(TeamMember teamMember)
        {
            teamMember.SetChatroom(this);
            _teamMembers.TryAdd(teamMember.Name, teamMember);
        }

        public void Send(string from, string message)
        {
            foreach (var teamMember in _teamMembers.Values)
            {
                teamMember.Receive(from, message);
            }
        }
    }
}