struct node
{
	int value;
	struct node* next;
};

void print_elements(struct node* head)
{
	struct node* p = head;
	while (p != NULL)
	{
		printf("%d\n", p->value);
		p = p->next;
	}
}

void add_first(struct node** head, int d)
{
	struct node* p;
	p = (struct node*)malloc(sizeof(struct node));
	p->value = d;
	p->next = *head;
	*head = p;
}

void add_new(struct node** current, int value)
{
	struct node* newNode;
	newNode = (struct node*)malloc(sizeof(struct node));
	newNode->value = value;
	newNode->next = NULL;
	struct node* last = *current;

	last->next = newNode;
}

void add_last(struct node** prevRef, int d)
{
	struct node* newNode;
	newNode = (struct node*)malloc(sizeof(struct node));

	struct node* last = *prevRef;
	newNode->next = NULL;
	newNode->value = d;

	if (*prevRef == NULL)
	{
		*prevRef = newNode;
		return;
	}

	last->next = newNode;
}

struct node* create_node2()
{
	int value = 1;
	struct node** headRef = (struct node**)malloc(sizeof(struct node));
	printf("0 is the last element of the List\n");
	*headRef = NULL;

	scanf("%d", &value);
	add_first(headRef, value);
	struct node* current = *headRef;

	while (value != 0)
	{
		scanf("%d", &value);
		add_last(current, value);
		current = current->next;
	}

	return *headRef;
}

int main()
{
	/*struct node *head;
	struct node *one = malloc(sizeof(struct node));
	struct node* two = malloc(sizeof(struct node));
	struct node* three = malloc(sizeof(struct node));
	struct node* four = malloc(sizeof(struct node));

	one->next = two;
	two->next = three;
	three->next = four;
	four->next = NULL;
	head = one;

	one->value = 1;
	two->value = 2;
	three->value = 3;
	four->value = 50;

	struct node** newHead = malloc(sizeof(struct node));
	*newHead = head;*/


	struct node* head = create_node2();
	print_elements(head);
}