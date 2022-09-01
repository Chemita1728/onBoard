import { test, expect } from '@playwright/test';
test('test', async ({ page }) => {
    debugger; 
    
    // Go to https://localhost:7201/
    await page.goto('https://localhost:7201/');
    
    // Click #userName
    await page.locator('#userName').click();
    
    const [userNameResponse] = await Promise.all([
        page.waitForResponse(userNameResponse => userNameResponse.url().includes("")),
        // Fill #userName
        await page.locator('#userName').fill('Alfredo'),
        // Press Enter
        await page.locator('#userName').press('Enter'),
    ]);
    const clickCounterBefClick = parseInt(await page.locator('#timesClicked').inputValue());
    await expect( clickCounterBefClick !=  null ).toBeTruthy(); 

    // Click input:has-text("Button")
    const [buttonResponse] = await Promise.all([
        page.waitForResponse(buttonResponse => buttonResponse.url().includes("")),
        await page.locator('input:has-text("Button")').click(),
    ]);
    const clickCounterAfClick = parseInt(await page.locator('#timesClicked').inputValue());
    await expect( clickCounterAfClick == clickCounterBefClick + 1 ).toBeTruthy(); 

    const hours = parseInt(await page.locator('#hora').inputValue());
    await expect(hours !=  null).toBeTruthy(); 
    const mins = parseInt(await page.locator('#minuto').inputValue());
    await expect(mins !=  null).toBeTruthy(); 
    const secs = parseInt(await page.locator('#segundo').inputValue());
    await expect(secs !=  null).toBeTruthy(); 


});

