<script>
  import FetchBudget from "./Components/FetchBudget.svelte";
  import Button from "./Components/Button.svelte";
  import Nav from "./Components/Nav.svelte";
</script>

<main class="wrapper">
  <Nav />
  <FetchBudget />
  <section>
    <Button variant="primary">Toggle</Button>
    <Button variant="secondary">Toggle</Button>
  </section>
</main>

<style>
  :global(body) {
    background-color: #dff5f6;
    color: #091e20;
    transition: background-color 0.3s;
  }
  :global(body.dark-mode) {
    background-color: #091f20;
    color: #dff4f6;
  }
</style>
