<script lang="ts">
  import Accordion, { Panel, Header, Content } from "@smui-extra/accordion";
  let currency = "SEK";
  export let budget;
</script>

<main>
  <div class="accordion-container">
    <Accordion>
      {#each budget.expenses as expense}
        <Panel>
          <Header>{expense.name}</Header>
          {#each expense.items as item}
            <Content>
              <input
                class="expence-items--name"
                type="text"
                bind:value={item.name}
              />
              <input
                class="expence-items--amount"
                type="digit"
                min="0"
                bind:value={item.amount}
              />
              <div class="expence--currency">{currency}</div>
            </Content>
          {/each}
        </Panel>
      {/each}
    </Accordion>
  </div>
</main>

<!-- <style>
  .expence--items {
    display: inline-block;
    padding: 1px;
  }

  .expence-items--name {
    display: inline-block;
    width: 10rem;
    margin: 0 1rem 0 0;
  }

  .expence-items--amount {
    display: inline-block;
    width: 30px;
    margin: 0 0.5rem 0 0;
  }

  .expence--currency {
    display: inline-block;
  }
</style> -->
