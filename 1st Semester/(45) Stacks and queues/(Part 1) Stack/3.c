#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

<<<<<<< Updated upstream
struct Stack
{
    int data;
    struct Stack* next;
=======
struct node
{
    int data;
    struct node* next;
};

struct Stack
{
    struct node* head;
>>>>>>> Stashed changes
};

struct Stack* create_node(int data)
{
    struct Stack* stackNode = (struct Stack*)malloc(sizeof(struct Stack));
<<<<<<< Updated upstream
    stackNode->data = data;
    stackNode->next = NULL;
=======
    struct node* newNode = (struct Stack*)malloc(sizeof(struct Stack));
    newNode->data = data;
    newNode->next = NULL;
    stackNode->head = newNode;
}

struct Stack* is_empty(struct Stack* root)
{
    return !root;
>>>>>>> Stashed changes
}

void push(struct Stack** root, int data)
{
    struct Stack* newStackNode = create_node(data);
<<<<<<< Updated upstream
    newStackNode->next = *root;
=======
    newStackNode->head->next = *root;
>>>>>>> Stashed changes
    *root = newStackNode;
}

int pop(struct Stack** root)
{
<<<<<<< Updated upstream
    struct Stack* temp = *root;
    *root = (*root)->next;
    int popped = temp->data;
    free(temp);

=======
    if (is_empty(*root))
    {
        printf("Error. No elements found.\n");
        return 0;
    }

    struct Stack* temp = *root;
    *root = (*root)->head->next;
    int popped = temp->head->data;
    free(temp);
>>>>>>> Stashed changes
    return popped;
}

int reverse_polish_notation(struct Stack* stack)
{
    int temp = 0;
    char data[10];
    printf("Type \"Stop\" to stop\nType numbers or operands one by one\n");

    while (strcmp(data, "Stop"))
    {
        printf("The number/operand: ");
        scanf("%s", data);
        if (atoi(data))
        {
            push(&stack, atoi(data));
        }
        else if (!strcmp(data, "+"))
        {
            temp = pop(&stack);
<<<<<<< Updated upstream
            stack->data += temp;
            printf("The current number is: %d\n", stack->data);
=======
            stack->head->data += temp;
            printf("The current number is: %d\n", stack->head->data);
>>>>>>> Stashed changes
        }
        else if (!strcmp(data, "-"))
        {
            temp = pop(&stack);
<<<<<<< Updated upstream
            stack->data -= temp;
            printf("The current number is: %d\n", stack->data);
=======
            stack->head->data -= temp;
            printf("The current number is: %d\n", stack->head->data);
>>>>>>> Stashed changes
        }
        else if (!strcmp(data, "*"))
        {
            temp = pop(&stack);
<<<<<<< Updated upstream
            stack->data *= temp;
            printf("The current number is: %d\n", stack->data);
=======
            stack->head->data *= temp;
            printf("The current number is: %d\n", stack->head->data);
>>>>>>> Stashed changes
        }
        else if (!strcmp(data, "/"))
        {
            temp = pop(&stack);

            if (temp == 0)
                return -1;

<<<<<<< Updated upstream
            stack->data /= temp;
            printf("The current number is: %d\n", stack->data);
=======
            stack->head->data /= temp;
            printf("The current number is: %d\n", stack->head->data);
        }
        else if (!strcmp(data, "Stop"))
        {
            break;
>>>>>>> Stashed changes
        }
        else
        {
            printf("Error! Unknown symbol.\n");
        }
    }
    return pop(&stack);
}

int main()
{
    struct Stack* stack = create_node(0);
    printf("The result is %d", reverse_polish_notation(stack));
}
