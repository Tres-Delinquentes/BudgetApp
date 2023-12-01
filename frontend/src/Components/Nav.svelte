<script>
  export let budgetToDisplay = 0;
  $: console.log("budgettodisplay: " + budgetToDisplay);
  export let budgetTitle = "Name of budget";
</script>

<div class="full-bleed">
  <nav class="navbar">
    <div class="navbar-content">
      <h1 class="display">Budget Appen</h1>
        <p class="p">
          Lorem ipsum dolor sit, amet consectetur adipisicing elit. Non in eum
          distinctio libero adipisci, officia maxime aliquam corrupti iusto architecto
          amet eveniet harum quis quasi sed corporis nemo excepturi quam!
        </p>
      <div class="column-container">
        <div class="instructions mt-3">
            <h2>Hur man använder Budgetappen</h2>
              <ol>
                <li>
                  <strong>Välj en Mall</strong>
                  <br>
                    Börja med att välja ett av våra fördefinierade mallar eller skapa din egen budgetmall.
                  </li>
                <li>
                  <strong>Fyll i Din Inkomst</strong> 
                  <br>
                    Kom ihåg att inkludera alla dina inkomster, inte bara din lön, utan även andra källor som bidrag, extrajobb, och passiva inkomster.
                </li>
                <li>
                  <strong>Registrera Dina Utgifter</strong> 
                  <br>
                    Här kan du lägga till olika utgiftskategorier för att organisera dina kostnader. Exempel på kategorier kan vara 'Boende', 'Mat', 'Transport', 'Fritid', etc.
                </li>
                <li>
                  <strong>Lägg till Utgiftskategorier</strong> 
                  <br>
                    Du kan enkelt lägga till nya utgiftskategorier genom att använda 'Lägg till ny kategori'-knappen. Detta ger dig möjligheten att anpassa din budget efter dina unika behov och utgiftsmönster.
                </li>
                <li>
                  <strong>Anpassa och Uppdatera</strong> 
                  <br>
                    När du har lagt till dina inkomster och utgifter, kan du enkelt justera belopp och kategorier vid behov. Din totala budget kommer att uppdateras automatiskt för att reflektera dessa förändringar.
                </li>
              </ol>
            <p>Genom att följa dessa enkla steg kan du skapa och hantera en budget som hjälper dig att hålla koll på dina finanser och planera för framtiden.</p>
          </div>
        </div>
      </div>
  </nav>
</div>


<style>

  .navbar {
    padding: 60px;
    max-width: 100%;
    background-color: var(--clr-primary);
    color: var(--clr-text);
    margin-bottom: 1rem;
    font-family: "Poppins", sans-serif;
  }

  .navbar-content,
  .column-container {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
  }

  .column-container {
    display: grid;
    grid-template-columns: 1fr 3fr 1fr;
    gap: 1rem;
    margin-top: 1rem;
  }


 .instructions {
    grid-column: 2;
    max-width: 800px;
    margin: 0 auto;
    padding: 1rem;
    background-color: #f8f8f8;
    border-radius: 4px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  }

  .instructions h2 p {
    color: #091e20;
    text-align: center;
  }

  .instructions ol {

    list-style-type: none;
    padding-left: 1.5rem;
  }

  .instructions ol li {

    margin-bottom: 15px;
  }


  .instructions p {
    text-align: center;
    margin-top: 20px;
    font-style: italic;
    color: #333;
  }

  h1 {
    font-size: var(--fs-900);
    font-weight: 800;
  }

  p {
    color: #091e20;
  }
</style>
