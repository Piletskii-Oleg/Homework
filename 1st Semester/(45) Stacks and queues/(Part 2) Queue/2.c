#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct Queue //unfinished (when queue becomes empty)
{
    int data;
    struct Queue* next;
    struct Queue* bottom;
};

struct Queue* initialize(int data)
{
    struct Queue* head = (struct Queue*)malloc(sizeof(struct Queue));
    head->data = data;
    head->next = NULL;
    head->bottom = head;
    return head;
}

void push(struct Queue* queue, int element)
{
    struct Queue* newNode = (struct Queue*)malloc(sizeof(struct Queue));
    if (queue == NULL)
    {
        queue = newNode;
    }
    else
    {
        while (queue->next != NULL)
            queue = queue->next;
    }
    queue->next = newNode;
    newNode->data = element;
    newNode->next = NULL;
    printf("Element %d pushed to the queue.\n", element);
}

void pop(struct Queue** queue)
{
    if ((*queue) == NULL)
        printf("Queue is empty!");
    else
    {
        struct Queue* temp = (*queue)->bottom;
        (*queue) = (*queue)->next;
        if ((*queue) != NULL)
        {
            (*queue)->bottom = (*queue);
        }
        int popped = temp->data;
        free(temp);

        printf("Element %d popped.\n", popped);
    }
}

int main()
{
    struct Queue* head = initialize(4);
    push(head, 3);
    push(head, 6);
    pop(&head);
    pop(&head);
    pop(&head);
}
