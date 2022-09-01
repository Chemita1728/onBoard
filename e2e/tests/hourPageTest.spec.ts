import { test, expect } from '@playwright/test';
test('test', async ({ page }) => {
    
    
    // Go to https://localhost:7201/
    await page.goto('https://localhost:7201/');
    
    // Click #userName
    // await page.locator('text=Hour Page').click();
    await page.locator("a >> text=Hour Page").click();
    await expect(page).toHaveURL( 'https://localhost:7201/Users' );
    let counter: number = 1;

    const nextButton = await page.locator("a >> text=Next");

    let condition: boolean = await page.$eval("a >> text=Next", el => el.classList.contains("disabled"));
    // await expect(nextButton).toHaveClass(/disabled/);
    while( !condition ){
        const hours = await page.locator('.table').locator('tbody').locator('tr');
        const hourNumber = await hours.count();
        
        await expect( hourNumber > 0 && hourNumber <=10 ).toBeTruthy();
        debugger; 
        for (let i = 0; i < hourNumber; i++) {
            const row = await hours.nth(i).locator('td');
            for (let j = 0; j < 4; j++) {
                const td = await row.nth(j).innerText();
                await expect( td != null ).toBeTruthy();
            }
        }
        condition = await page.$eval("a >> text=Next", el => el.classList.contains("disabled"));
        if( !condition ){
            await nextButton.click();
            counter += 1;
            await expect(page).toHaveURL( 'https://localhost:7201/Users?pageNumber='+ counter );
        }
    }
    

    




    
});

