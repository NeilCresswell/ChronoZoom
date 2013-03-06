﻿using System;
using Framework.UserActions;
using OpenQA.Selenium;

namespace Framework.Helpers
{
    public class HomePageHelper : DependentActions
    {
        private readonly ApplicationManager _manager;

        public HomePageHelper()
        {
            _manager = new ApplicationManager();
        }
        public void CloseWelcomePopup()
        {
            Logger.Log("<-");
            ClickCloseButton();
            WaitCondition(()=>Convert.ToBoolean(GetJavaScriptExecutionResult("visReg != undefined")),60);
            Logger.Log("->");
        }

        public string GetEukaryoticCellsDescription()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().OpenExhibitEukaryoticCells();
            Logger.Log("ExhibitEukaryotic Cell is opened");
            string description = GetText(By.XPath("//*[@id='vc']/*[@class='contentItemDescription']/div"));
            Logger.Log("-> description: " + description);
            return description;
        }

        public void OpenLifeTimeline()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().OpenLifePage();
            WaitAnimation();
            Logger.Log("->");
        } 
        
        public void OpenHumanityTimeline()
        {
            Logger.Log("<-");
            _manager.GetNavigationHelper().OpenHumanityPage();
            WaitAnimation();
            Logger.Log("->");
        }

        public void OpenBceCeArea()
        {
            Logger.Log("<-");
            ExecuteJavaScript("controller.moveToVisible(new VisibleRegion2d(-2012.9408427494022, 222893683.28023896,0.001905849287056807),false)");
            WaitAnimation();
            Logger.Log("->");
        }

        public string GetLastBreadcrumbs()
        {
            Logger.Log("<-");
            WaitAnimation();
            string result = GetText(By.XPath("//*[@id='breadCrumbsTable']/*/tr/td[last()]/div"));
            Logger.Log("-> Last Breadcrumbs: " + result);
            return result;
        }
    }
}