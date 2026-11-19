using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    [SerializeField] GameObject diamond;
    [SerializeField] GameObject van;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Node steal = new Node("Steal Something");
        Leaf goToDiamond = new Leaf("Go to Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go to Van", GoToVan);

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();
        tree.Process();
    }

    public Node.Status GoToDiamond()
    {
        agent.SetDestination(diamond.transform.position);
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToVan()
    {
        agent.SetDestination(van.transform.position);
        return Node.Status.SUCCESS;
    }
}
