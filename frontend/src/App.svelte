<script>
  import svelteLogo from './assets/svelte.svg'
  import viteLogo from '/vite.svg'
  import Counter from './lib/Counter.svelte'
  import FetchBudget from './Components/FetchBudget.svelte'
  import Button from './Components/Button.svelte'
  import Nav from './Components/Nav.svelte'
</script>

<style>
  :global(body) {
    background-color: #dff5f6;
    color: #091e20;;
    transition: background-color 0.3s;
  }
  :global(body.dark-mode) {
    background-color: #091f20;
    color: #dff4f6;
  }
</style>

  <main>
    <Nav />
    <section>
      <h1>detta är ett test!</h1>
    <Button variant="primary">Toggle</Button>
    <Button variant="secondary">Toggle</Button>
  </section>
</main>


