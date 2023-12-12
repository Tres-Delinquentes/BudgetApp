<script>
  import FetchBudget from "./Components/Functions/FetchBudget.svelte";
  import Nav from "./Components/Nav.svelte";
  import Accordion from "./Components/Accordion.svelte";
  import Income from "./Components/Income.svelte";
  import ContentRight from "./Components/ContentRight.svelte";

  let budgetToDisplay = 0;
  let titleForBudget = "";
  let titleDescription = "";
  let budget = {
    title: titleForBudget,
    expenses: [],
    income: {},
    description: titleDescription,
  };

  let budgetList = { expenses: [], income: [] };
  $: console.log("budget from app " + budgetList);

  $: budget.description = titleDescription;
  $: budget.title = titleForBudget;
</script>

<FetchBudget bind:budgetList />

<div class="container">
  <nav class="navbar">
    <Nav />
  </nav>

  <div class="main-content">
    {#if budgetList && budgetList.length > 0}
      <div class="left">
        <h1 class="content-display">Dina uppgifter</h1>
        <div class="income-container">
          <Income bind:budget {budgetList} {budgetToDisplay} />
        </div>
        <input
          class="budget-title"
          type="text"
          placeholder="Namn på din budget"
          bind:value={titleForBudget}
        />
        <br />
        <textarea
          rows="4"
          maxlength="250"
          placeholder="Beskrivning av din budget"
          bind:value={titleDescription}
        />
        <br />
        <div class="choose-budget">
          <p>
            Välj en utav våra tre fördefinierade mallar eller skapa din egna.
          </p>
          <div class="choose-budget-buttons">
            <button class="numberbtn" on:click={() => (budgetToDisplay = 0)}
              >1</button
            >
            <button class="numberbtn" on:click={() => (budgetToDisplay = 1)}
              >2</button
            >
            <button class="numberbtn" on:click={() => (budgetToDisplay = 2)}
              >3</button
            >
            <button class="numberbtn" on:click={() => (budgetToDisplay = 3)}
              >Tom</button
            >
          </div>
        </div>
        <h1 class="content-display">Utgifter</h1>
        <Accordion
          bind:budget
          {budgetList}
          {budgetToDisplay}
          {titleForBudget}
        />
      </div>
      <div class="right">
        <h1 class="content-display">Sammanställning</h1>
        <ContentRight {budget} />
      </div>
    {/if}
  </div>
  <footer class="footer">
    <p>© 2023 Tres Delinquentes. Alla rättigheter förbehållna.</p>
    <p>Skapad med passion och expertis av tre entusiaster inom budgetering.</p>
    <p>
      Följ oss på sociala medier för fler tips och uppdateringar om smart
      budgetering.
    </p>
  </footer>
</div>

<style>
  .container {
    display: flex;
    flex-direction: column;
    min-height: 100vh;
  }

  .navbar {
    color: #dff5f6;
    background-color: #091f20;
    margin-bottom: 1rem;
  }

  .main-content {
    display: flex;
    flex-direction: column;
    flex: 1;
  }

  .left {
    width: 100%;
    padding: 1.5rem;
  }

  .budget-title {
    justify-content: center;
    align-items: center;
    margin: 0.5rem 0;
  }

  .content-display {
    text-align: center;
  }

  .income-container {
    margin-bottom: 0.5rem;
  }

  .choose-budget {
    justify-content: center;
    align-items: center;
    text-align: center;
    width: 100%;
    padding: 1rem;
  }

  .choose-budget-buttons {
    margin-top: 1rem;
  }

  .right {
    max-width: 100%;
    padding: 1.5rem;
  }

  .footer {
    background-color: #091f20;
    color: white;
    text-align: center;
    padding: 1rem;
    border-top: 2px solid #091f20;
    margin-top: 1rem;
  }

  @media (min-width: 768px) {
    .main-content {
      flex-direction: column;
    }

    .navbar {
      margin-bottom: 1rem;
    }

    .content-display {
      font-size: var(--fs-500);
    }

    .left,
    .right {
      flex: 1;
      padding: 1.5rem;
    }
  }

  @media (min-width: 1024px) {
    .navbar {
      margin-bottom: 1rem;
    }

    .main-content {
      flex-direction: row;
    }

    .left {
      padding: 2rem;
      margin: 3rem;
      flex: 1;
    }

    .right {
      padding: 2rem;
      margin: 3rem;
      flex: 1;
    }

    .left,
    .right {
      flex: 1;
      margin-bottom: 1rem;
    }

    .content-display {
      text-align: start;
      font-size: var(--fs-500);
    }

    .footer {
      margin-top: 2rem;
    }
  }

  textarea {
    width: 100%;
    padding: 10px;
    border: 2px solid #091f20;
    border-radius: 4px;
    font-family: inherit;
    font-size: 1em;
    resize: none;
  }
</style>
