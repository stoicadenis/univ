#define MAX 20

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct medicament
{
  char nume[MAX];
  int cantitate;
  struct medicament *urm;
} medicament;

typedef struct reteta
{
  char nume[MAX];
  struct medicament *sublista;
  struct reteta *urm;
}reteta;

typedef struct stoc
{
  char nume[MAX];
  int cantitate;
  float pret;
  struct stoc *urm;
}stoc;

// --- Functii pentru cautare ---

// Functie cautare reteta
reteta *caut_reteta(reteta *lista, char *nume)
{
  reteta *q;
  for(q=lista; q!=NULL && strcmp(q->nume, nume); q=q->urm);
  return q;
}

// Functie cautare medicament reteta
medicament *caut_medicament(medicament *sublista, char *pill)
{
  medicament *m;
  for(m=sublista; m!=NULL && strcmp(m->nume, pill); m=m->urm);
  return m;
}

// Functie cautare stoc
stoc *caut_stoc(stoc *lista, char *nume)
{
  stoc *q;
  for(q=lista; q!=NULL && strcmp(q->nume, nume); q=q->urm);
  return q;
}

// --- Functii pentru adaugare ---

// Functie adaugare reteta
reteta *add_reteta(reteta *lista, char *nume)
{
  reteta *q1, *q2, *aux;
  aux=(reteta*)malloc(sizeof(reteta));
  strcpy(aux->nume, nume);
  aux->urm=NULL;
  aux->sublista=NULL;
  for(q1=q2=lista; q1 != NULL && strcmp(q1->nume, aux->nume) < 0; q2=q1, q1=q1->urm);
  if(q1==q2)
  {
    aux->urm=lista;
    lista=aux;
  }
  else
  {
    q2->urm=aux;
    aux->urm=q1;
  }
  return lista;
}

// Functie adaugare medicament
medicament *add_med(medicament *lista, char *nume, int cantitate)
{
  medicament *q1, *q2, *aux;
  aux=(medicament*)malloc(sizeof(medicament));
  strcpy(aux->nume, nume);
  aux->cantitate = cantitate;
  aux->urm=NULL;
  for(q1=q2=lista; q1 != NULL && strcmp(q1->nume, aux->nume) < 0; q2=q1, q1=q1->urm);
  if(q1==q2)
  {
    aux->urm=lista;
    lista=aux;
  }
  else
  {
    q2->urm=aux;
    aux->urm=q1;
  }
  return lista;
}

// Functie adaugare stoc
stoc *add_stoc(stoc *lista, char *medicament, int cantitate, float pret)
{
  stoc *q1, *q2, *aux;
  aux=(stoc*)malloc(sizeof(stoc));
  strcpy(aux->nume, medicament);
  aux->cantitate=cantitate;
  aux->pret=pret;
  aux->urm=NULL;
  for(q1=q2=lista; q1 != NULL && strcmp(q1->nume, aux->nume) < 0; q2=q1, q1=q1->urm);
  if(q1==q2)
  {
    aux->urm=lista;
    lista=aux;
  }
  else
  {
    q2->urm=aux;
    aux->urm=q1;
  }
  return lista;
}

// Functie adaugare medicament in stoc
stoc *add_medstoc(stoc *lista)
{
  char nume[MAX];
  int cantitate;
  float pret;
  printf("\tIntroduceti numele medicamentului: ");
  getchar();
  scanf("%s", nume);
  if(caut_stoc(lista, nume)==NULL)
  {
    printf("\tIntroduceti cantitatea: ");
    scanf("%d", &cantitate);
    printf("\tIntroduceti pretul: ");
    scanf("%f", &pret);
    lista=add_stoc(lista, nume, cantitate, pret);
    printf("\tMedicamentul a fost adaugat cu succes in sistem!\n");
  }
  else
    printf("\tMedicamentul se afla deja in sistem!\n");
  return lista;
}

// Functii pentru stergere

// Functie stergere reteta
reteta *del_reteta(reteta *lista)
{
  char nume[MAX];
  reteta *q1, *q2;
  printf("\tIntroduceti reteta care trebuie stearsa: ");
  scanf("%s", nume);
  if(caut_reteta(lista, nume))
  {
    for(q1=q2=lista;q1!=NULL && strcmp(q1->nume, nume); q2=q1, q1=q1->urm);
    if(q1 != NULL && strcmp(q1->nume, nume) == 0)
    {
      if(q1 == q2)
      {
        lista=lista->urm;
      }
      else
      {
        q2->urm=q1->urm;
        free(q1);
      }
      printf("\tReteta a fost stearsa din sistem cu succes!\n");
      return lista;
    }
  }
  else
    printf("\tReteta citita nu exista in sistem!\n");
  return lista;
}

// Functie stergere medicament stoc
stoc *del_medstoc(stoc *lista)
{
  char nume_med[MAX];
  stoc *q1, *q2;
  printf("\tIntroduceti numele medicamentului pe care doriti sa-l stergeti din stoc: ");
  getchar();
  scanf("%s", nume_med);
  if(caut_stoc(lista, nume_med))
  {
    for(q1=q2=lista; q1!=NULL && strcmp(q1->nume, nume_med); q2=q1, q1=q1->urm);
      if(q1 != NULL && strcmp(q1->nume, nume_med) == 0)
      {
        if(q1 != q2)
        {
          q2->urm=q1->urm;
          free(q1);
        }
        else
        {
          lista=lista->urm;
        }
      }
    printf("\tMedicamentul a fost sters din sistem cu succes!\n");
    return lista;
  }
  else
    printf("\tMedicamentul nu se afla pe stoc!\n");
  return lista;
}

// --- Functii pentru citire ---

// Functie citire reteta
reteta *cit_reteta(reteta *lista)
{
  FILE *f= fopen("retete.txt", "rt");
  if(!f)
  {
    perror("Eroare la citirea fisierului!");
    exit(EXIT_FAILURE);
  }
  medicament *med=NULL;
  reteta *ret=NULL;
  char nume[MAX], pill[MAX];
  int cantitatea;
  while(!feof(f))
  {
    fscanf(f, "%s %s %d", nume, pill, &cantitatea);
    if(caut_reteta(lista, nume)==NULL)
            lista= add_reteta(lista, nume);
    ret = caut_reteta(lista, nume);
    med = ret->sublista;
    if(caut_medicament(med, pill)==NULL)
            med = add_med(med, pill, cantitatea);
    ret->sublista=med;
  }
  fclose(f);
  return lista;
}

// Functie citire stoc
stoc *cit_stoc(stoc *lista)
{
  FILE *f=fopen("stoc.txt", "rt");
  if(!f)
  {
    perror("Eroare la citirea fisierului!");
    exit(EXIT_FAILURE);
  }
  char medicament[MAX];
  int cantitate;
  float pret;
  while(!feof(f))
  {
    fscanf(f, "%s %d %f", medicament, &cantitate, &pret);
    if(caut_stoc(lista, medicament) == NULL)
            lista=add_stoc(lista, medicament, cantitate, pret);
  }
  fclose(f);
  return lista;
}

// --- Functii afisare ---

// Functie afisare retete
void afisare_retete(reteta *lista)
{
  reteta *ret = NULL;
  medicament *med = NULL;
  for(ret=lista; ret!=NULL;ret=ret->urm)
  {
    printf("%s\n", ret->nume);
    if(ret->sublista != NULL)
    {
      for(med=ret->sublista;med!=NULL;med=med->urm)
      {
        printf("\t%s %d\n", med->nume, med->cantitate);
      }
    }
  }
}

// Functie afisare stoc
void afisare_stoc(stoc *lista)
{
  stoc *st=NULL;
  for(st=lista; st!=NULL; st=st->urm)
  {
    printf("\t%s %d %.2f\n", st->nume, st->cantitate, st->pret);
  }
}

//
// --- Alte functii ---

// Functie verificare
void verificare(reteta *lista_retete, stoc *stoc_depozit)
{
  reteta *ret=NULL;
  medicament *m=NULL;
  stoc *st=NULL;
  char nume_reteta[MAX];
  float suma=0;
  printf("\tCiteste reteta: ");
  getchar();
  scanf("%s", nume_reteta);
  ret=caut_reteta(lista_retete, nume_reteta);
  if(ret)
  {
    for(m=ret->sublista;m!=NULL;m=m->urm)
    {
      st=caut_stoc(stoc_depozit, m->nume);
      if(st)
      {
        if(st->cantitate>m->cantitate)
        {
          suma = suma + st->pret*m->cantitate;
        }
        else
        {
          printf("\tNu este suficient %s, cantitate in depozit: %d, cantitate necesara: %d\n", m->nume, st->cantitate, m->cantitate);
          suma=0;
          break;
        }
      }
      else{
        printf("\tNu exista un/ mai multe produs/e necesare in depozit!\n");
        suma=0;
        break;
      }
    }
    if(suma)
       printf("\tPretul total este: %.2f\n", suma);
  }
  else
    printf("\tReteta citita nu exista!\n");
}

// Functie reteta noua
reteta *reteta_noua(reteta *lista)
{
  reteta *ret=NULL;
  int val, cantitate;
  char nume[MAX];
  printf("\tIntroduceti noua reteta: ");
  getchar();
  scanf("%s", nume);
  ret = caut_reteta(lista, nume);
  if(ret==NULL)
  {
      lista=add_reteta(lista, nume);
  }
  else
      printf("\tReteta exista deja in sistem!\n");
  printf("\tDoriti sa incarcati medicamente?(0 - NU / 1 - DA)\n");
  scanf("%d", &val);
  if(val == 1)
  {
    medicament *m=NULL;
    ret=caut_reteta(lista, nume);
    while(val==1)
    {
      printf("\tCum se numeste medicamentul?\n");
      getchar();
      scanf("%s", nume);
      printf("\tCe cantitate este necesara?\n");
      scanf("%d", &cantitate);
      m=ret->sublista;
      if(caut_medicament(m, nume)==NULL)
      {
        m=add_med(m, nume, cantitate);
        printf("\tMedicamentul a fost adaugat cu succes!\n");
      }
      else
        printf("Exista deja acest medicament!\n");
      ret->sublista=m;
      printf("Doriti sa adaugati alt medicament?(0 - NU / 1 - DA)\n");
      scanf("%d", &val);
    }
  }
  return lista;
}

// Functie modificare medicament stoc
stoc *mod_medstoc(stoc *lista)
{
  char nume_med[MAX];
  stoc *q1, *q2;
  printf("\tIntroduceti numele medicamentului pe care doriti sa-l modificati: ");
  getchar();
  scanf("%s", nume_med);
  if(caut_stoc(lista, nume_med))
  {
    for(q1=q2=lista;q1!=NULL && strcmp(q1->nume, nume_med); q2=q1, q1=q1->urm);
    if(q1!=NULL && strcmp(q1->nume, nume_med)==0)
    {
      int val;
      printf("\tCe doriti sa modificati (0 - CANTITATEA / 1 - PRETUL)?\n");
      scanf("%d", &val);
      if(!val)
      {
        int cantitate;
        printf("\tIntroduceti noua cantitate: ");
        scanf("%d", &cantitate);
        q1->cantitate=cantitate;
      }
      else if (val == 1)
      {
        float pret;
        printf("\tIntroduceti noul pret: ");
        scanf("%f", &pret);
        q1->pret=pret;
      }
    }
  }
  else
    printf("\tMedicamentul nu se afla pe stoc!\n");
  return lista;
}

// Functie salvare date
void save(reteta *lista_retete, stoc *stoc_depozit)
{
  FILE *f=fopen("retete_nou.txt", "wt");
  FILE *g=fopen("stoc_nou.txt", "wt");
  reteta *q;
  medicament *m;
  stoc *st;
  if(!f || !g)
  {
    perror("Eroare la deschiderea fisierului!");
    exit(EXIT_FAILURE);
  }
  for(q=lista_retete;q!=NULL;q=q->urm)
  {
    fprintf(f, "%s\n", q->nume);
    for(m=q->sublista;m!=NULL;m=m->urm)
       fprintf(f, "\t%s %d\n", m->nume, m->cantitate);
  }
  fclose(f);
  for(st=stoc_depozit;st!=NULL;st=st->urm)
     fprintf(g, "%s %d %f\n", st->nume, st->cantitate, st->pret);
   fclose(g);
}

// MAIN

int main()
{
  int opt, val;
  char nume_med[MAX];
  reteta *lista_retete = NULL;
  stoc *stoc_depozit = NULL;
  do
  {
    printf("0. Iesire\n");
    printf("1. Incarcati datele\n");
    printf("2. Afiseaza lista retelor in ordine alfabetica\n");
    printf("3. Verifica daca exista toate medicamentele pentru o reteta si afiseaza pretul\n");
    printf("4. Afiseaza lista medicamentelor din stoc in ordine alfabetica\n");
    printf("5. Adauga/ sterge o reteta\n");
    printf("6. Adauga/ sterge/ modifica un medicament\n");
    printf("7. Salveaza retetele si medicamentele\n");
    printf("Care este optiunea dorita?\n");
    scanf("%d", &opt);
    switch (opt) {
      case 0: exit(EXIT_FAILURE);
              break;
      case 1:
              if(!lista_retete && !stoc_depozit)
              {
                lista_retete=cit_reteta(lista_retete);
                stoc_depozit=cit_stoc(stoc_depozit);
                printf("Datele au fost incarcate cu succes!\n");
              }
              else
                printf("Datele au fost deja incarcate!\n");
              break;
      case 2:
              if(lista_retete && stoc_depozit)
              {
                printf("Lista retete\n");
                afisare_retete(lista_retete);
                printf("\nLista Stoc Depozit\n");
                afisare_stoc(stoc_depozit);
              }
              else
                printf("Datele nu au fost incarcate!\n");
              break;
      case 3:
              if(lista_retete && stoc_depozit)
              {
                verificare(lista_retete, stoc_depozit);
              }
              else
                printf("Datele nu au fost incarcate!\n");
              break;
      case 4:
              if(lista_retete && stoc_depozit)
              {
                afisare_stoc(stoc_depozit);
              }
              else
                printf("Datele nu au fost incarcate!\n");
              break;
      case 5:
              if(lista_retete)
              {
                printf("\tCe optiune alegeti (0 - STERGERE / 1 - ADAUGARE): ");
                scanf("%d", &val);
                if(!val) lista_retete = del_reteta(lista_retete);
                else if (val == 1) lista_retete = reteta_noua(lista_retete);
                else printf("\tOptiune invalida!\n");
              }
              else
                printf("Datele nu au fost incarcate!\n");
              break;
      case 6:
              if(stoc_depozit)
              {
                printf("\tCe optiune alegeti (0 - STERGERE / 1 - ADAUGARE / 2 - MODIFICARE): ");
                scanf("%d", &val);
                if(!val) stoc_depozit = del_medstoc(stoc_depozit);
                else if(val == 1) stoc_depozit = add_medstoc(stoc_depozit);
                else if(val == 2) stoc_depozit = mod_medstoc(stoc_depozit);
                else printf("\tOptiune invalida!\n");
              }
              else
                printf("\tDatele nu au fost incarcate!\n");
              break;
      case 7:
              if(lista_retete && stoc_depozit)
              {
                save(lista_retete, stoc_depozit);
              }
              else
                printf("Datele nu au fost incarcate!\n");
              break;
      default:
              printf("\tOptiunea citita este invalida!\n");
              break;
    }
  } while(1);
  return 0;
}
