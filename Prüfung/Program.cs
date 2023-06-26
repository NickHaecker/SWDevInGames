// UIElement dialog =
// new Group
// {
//     Name = "Ein Dialog",
//     Children = new List<UIElement>(new UIElement[] {
//  new Label {Name="Label Eins", Contents="Hier steht was"},
//  new Image {Name="Bild Eins", Path="Smiley.jpg", Width=400, Height=300},
//  new TextInput {Name="Input", Text="Hier was eingeben" },
// })
// };
// SimpleTestVisitor v = new SimpleTestVisitor();
// dialog.Accept(v);

// // var i = "test";

// // i = 4;

// // Console.WriteLine(i);




 int i = 42;
  object o = i;
  o = 43;
  int j = (int)o;
  Console.WriteLine("i is: " + i + "; o is: " + o + "; j is: " + j);






// public class UIElement
// {
//     public string Name = "";
//     public virtual void Accept(Visitor v) { }
// }

// public class Label : UIElement
// {
//     public string Contents = "";
//     public override void Accept(Visitor v) { v.Visit(this); }
// }

// public class TextInput : UIElement
// {
//     public string Text = "";
//     public override void Accept(Visitor v) { v.Visit(this); }
// }

// public class Image : UIElement
// {
//     public string? Path;
//     public int Width, Height;
//     public override void Accept(Visitor v) { v.Visit(this); }
// }

// public class Group : UIElement
// {
//     public List<UIElement> Children = new List<UIElement>();

//     public override void Accept(Visitor v)
//     {
//         v.Visit(this);
//         if (Children != null)
//         {
//             foreach (UIElement uiElement in Children)
//             {
//                 uiElement.Accept(v);
//             }
//         }
//     }
// }

// public class Visitor
// {
//     public virtual void Visit(UIElement e) { }
//     public virtual void Visit(Label l) { }
//     public virtual void Visit(TextInput t) { }
//     public virtual void Visit(Image i) { }
//     public virtual void Visit(Group g) { }
// }

// public class SimpleTestVisitor : Visitor
// {
//     public override void Visit(UIElement e)
//     {
//         Console.WriteLine("Unknown");
//     }
//     public override void Visit(Label l)
//     {
//         Console.WriteLine(l.Name + " is a Label: " + l.Contents);
//     }
//     public override void Visit(TextInput t)
//     {
//         Console.WriteLine(t.Name + " is a TextInput: " + t.Text);
//     }
//     public override void Visit(Image i)
//     {
//         Console.WriteLine(i.Name + " is an image. Size: (" + i.Width + "," + i.Height + ")");
//     }
//     public override void Visit(Group g)
//     {
//         Console.WriteLine(g.Name + " is a Group with " + g.Children.Count + " children.");
//     }
// }


