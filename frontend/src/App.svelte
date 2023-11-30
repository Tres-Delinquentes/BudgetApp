<script>
  import FetchBudget from "./Components/Functions/FetchBudget.svelte";
  import Nav from "./Components/Nav.svelte";
  import Accordion from "./Components/Accordion.svelte";
  // import budgetToDisplay from "./Components/Nav.svelte";

  let budgetToDisplay;

  let budgetList = { expenses: [], income: [] };
  $: console.log("budget from app " + budgetList);
</script>

<FetchBudget bind:budgetList />
<main class="wrapper">
  <Nav bind:budgetToDisplay />
  {#if budgetList && budgetList.length > 0}
    <div class="wrapper">
      <div class="content-first">
        <Accordion {budgetList} {budgetToDisplay} />
      </div>
      <div class="content-second"></div>
    </div>
  {/if}
</main>

<style>
</style>
