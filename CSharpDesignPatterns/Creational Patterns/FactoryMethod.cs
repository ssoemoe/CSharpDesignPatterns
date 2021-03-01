/// <summary>
/// Author: Shane Moe
/// There are 4 components in the design pattern
/// 1. Product - interface of objects/abstract parent class of objects the factory method creates
/// 2. ConcreteProduct - implements the interface or inherits the abstract class
/// 3. Creator - parent class which contains the factory method which returns a default ConcreteProduct object
/// 4. ConcreteCreator - inherits the Creator class to override the factory method
/// 
/// Side note: abstract factory design pattern includes multiple factory methods
/// </summary>

using System;
using System.Collections.Generic;

namespace CSharpDesignPatterns.Creational_Patterns
{
    public class FactoryMethod
    {
        public static void TestFactoryMethodDesignPattern()
        {
            var htmlContentCreator = new HtmlContentCreator();
            var values = new Dictionary<string, string>
            {
                { "Src", "https://www.images.com/abcde" },
                { "Alt", "ABCDE are first five English alphabets." },
                { "Content", "This is inside a div" }
            };
            var img = htmlContentCreator.GetMarkUpContent("img", values);
            var div = htmlContentCreator.GetMarkUpContent("div", values);
            Console.WriteLine($"Image tag: {img.CreateContent()}");
            Console.WriteLine($"Div tag: {div.CreateContent()}");
        }
    }

    /// <summary>
    /// Product abstract class
    /// </summary>
    abstract class MarkUp
    {
        public string Tag { get; set; }
        public bool NeedsClosingTag { get; set; } = true;
        public abstract string CreateContent();
        public override string ToString()
        {
            return NeedsClosingTag ? $"<{Tag}></{Tag}>" : $"<{Tag}/>";
        }
    }

    /// <summary>
    /// Image - ConcreteProduct
    /// </summary>
    class Image : MarkUp
    {
        public string Src { get; set; }
        public string Alt { get; set; }
        public override string CreateContent()
        {
            return $"<{Tag} src=\"{Src}\" alt=\"{Alt}\"/>";
        }
    }

    /// <summary>
    /// Div - ConcreteProduct
    /// </summary>
    class Div : MarkUp
    {
        public string Content { get; set; }
        public override string CreateContent()
        {
            return $"<{Tag}>{Content}</{Tag}>";
        }
    }

    /// <summary>
    /// Creator interface
    /// </summary>
    interface MarkUpContentCreator
    {
        MarkUp GetMarkUpContent(string tag, Dictionary<string, string> values);
    }

    /// <summary>
    /// ConcreteCreator - inherits MarkUpContentCreator
    /// 
    /// Side note: we can just create another ConcreteCreator such as XmlContentCreator using MarkUpContentCreator
    /// </summary>
    class HtmlContentCreator : MarkUpContentCreator
    {
        public MarkUp GetMarkUpContent(string tag, Dictionary<string, string> values)
        {
            switch(tag)
            {
                case "img":
                    return new Image
                    {
                        Tag = tag,
                        NeedsClosingTag = false,
                        Src = values[nameof(Image.Src)],
                        Alt = values[nameof(Image.Alt)]
                    };
                case "div":
                    return new Div
                    {
                        Tag = tag,
                        NeedsClosingTag = true,
                        Content = values[nameof(Div.Content)]
                    };
                default:
                    return null;
            }
        }
    }
}
