#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct 
{
    char nume_elev[20];
    int nr_mat;
    float n1, n2, n3, media;
}elev;

typedef struct 
{
    char nume_elev[20];
    int nr_mat;
    float media;
}elev_corigent;

void citire(elev *e, int n)
{
    for(int i=0; i<n; i++)
    {
        printf("Numele elevului %d este: ", i+1);
        scanf("%s", e[i].nume_elev);
        printf("Numarul matricol este: ");
        scanf("%d", &e[i].nr_mat);
        printf("Notele elevului sunt: ");
        scanf("%f%f%f", &e[i].n1, &e[i].n2, &e[i].n3);
        if(e[i].n1 >= 5 && e[i].n2 >= 5 && e[i].n3 >= 5)
            e[i].media= (e[i].n1 + e[i].n2 + e[i].n3)/3;
        else 
          e[i].media=0;
    }
}

void afisare(elev *e, int n)
{
    for(int i=0;i<n;i++)
    {
        printf("Numele elevului %d este: %s\n", i+1, e[i].nume_elev);
        printf("\t Numarul matricol este: %d\n", e[i].nr_mat);
        printf("\t Notele elevului sunt: %f %f %f\n", e[i].n1, e[i].n2, e[i].n3);
        printf("\t Media elevului este: %f\n", e[i].media);
    }
}

void afisare_c(elev_corigent *ec, int k)
{
    for(int i=0;i<k;i++)
    {
        printf("Numele elevului %d este: %s\n", i+1, ec[i].nume_elev);
        printf("\t Numarul matricol este: %d\n", ec[i].nr_mat);
        printf("\t Media elevului este: %f\n", ec[i].media);
    }
}

void sort(elev *e, int n)
{
    int i, j;
    elev aux;
    for(i=0;i<n-1;i++)
       for(j=i+1;j<n;j++)
          if(strcmp(e[i].nume_elev, e[j].nume_elev) > 0)
          {
              aux=e[i];
              e[i]=e[j];
              e[j]=aux;
          }
    afisare(e,n);
}

int caut_corigenti(elev *e, elev_corigent *ec, int n)
{
    int i, k=0;
    float media;
    for(i=0; i<n;i++)
    {
        media = (e[i].n1 + e[i].n2 + e[i].n3)/3;
        if(media<5)
        {
            strcpy(ec[k].nume_elev,e[i].nume_elev);
            ec[k].nr_mat=e[i].nr_mat;
            ec[k].media=media;
            k++;
        }
    }
    return k;
}

int main(void)
{
    elev e[10];
    elev_corigent ec[10];
    int opt, n=0, k;
    do
    {
        printf("0. Iesire\n");
        printf("1. Citire date pentru n elevi\n");
        printf("2. Afisare pe ecran lista elevi\n");
        printf("3. Sortare lista elevi in ordine alfabetica\n");
        printf("4. Cautare elevi corigenti si adaugarea acestora in alta lista + afisare\n");
        printf("Ce optiune alegeti: ");
        scanf("%d", &opt);
        switch(opt)
        {
            case 0: 
            exit(EXIT_SUCCESS);
            break;
            case 1:
            if(!n)
            {
                printf("Cati elevi sunt?\n");
                scanf("%d", &n);
                citire(e,n);
            }
            else
              printf("Au fost deja cititi elevii!\n");
            break;
            case 2:
            afisare(e,n);
            break;
            case 3:
            sort(e,n);
            break;
            case 4:
            k = caut_corigenti(e, ec, n);
            afisare_c(ec, k);
            break;
            default:
            printf("Optiunea aleasa este invalida!\n");
            break;
        }
    } while (1);
    
}