#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct Stack
{
    int data;
    struct Stack* next;
};

struct Stack* create_node(int data)
{
    struct Stack* stackNode = (struct Stack*)malloc(sizeof(struct Stack));
    stackNode->data = data;
    stackNode->next = NULL;
}

void push(struct Stack** root, int data)
{
    struct Stack* newStackNode = create_node(data);
    newStackNode->next = *root;
    *root = newStackNode;
}

int pop(struct Stack** root)
{
    struct Stack* temp = *root;
    *root = (*root)->next;
    int popped = temp->data;
    free(temp);

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
            stack->data += temp;
            printf("The current number is: %d\n", stack->data);
        }
        else if (!strcmp(data, "-"))
        {
            temp = pop(&stack);
            stack->data -= temp;
            printf("The current number is: %d\n", stack->data);
        }
        else if (!strcmp(data, "*"))
        {
            temp = pop(&stack);
            stack->data *= temp;
            printf("The current number is: %d\n", stack->data);
        }
        else if (!strcmp(data, "/"))
        {
            temp = pop(&stack);

            if (temp == 0)
                return -1;

            stack->data /= temp;
            printf("The current number is: %d\n", stack->data);
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
