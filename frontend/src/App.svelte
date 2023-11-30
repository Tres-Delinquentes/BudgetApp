<script>
  import FetchBudget from "./Components/FetchBudget.svelte";
  import Nav from "./Components/Nav.svelte";
  import Accordion from "./Components/Accordion.svelte";
  import Income from "./Components/Income.svelte";
  let budget = { expenses: [], income: [] };
</script>

<main class="wrapper">
  <Nav />
  <div class="wrapper">
    <div class="content-first">
      <Accordion {budget} />
    </div>
    <div class="content-second"></div>
    <Income {budget} />
  </div>
  <FetchBudget bind:budget />
</main>

<style>
</style>
